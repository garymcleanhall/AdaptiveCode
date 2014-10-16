using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace UI.AspNetMvc.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public TaskController() : this(IdentityConfig.Secrets, IdentityConfig.Logins, IdentityConfig.Users, IdentityConfig.Roles) { }

        public TaskController(IUserSecretStore secrets, IUserLoginStore logins, IUserStore users, IRoleStore roles)
        {
            Secrets = secrets;
            Logins = logins;
            Users = users;
            Roles = roles;
        }

        public IUserSecretStore Secrets { get; private set; }
        public IUserLoginStore Logins { get; private set; }
        public IUserStore Users { get; private set; }
        public IRoleStore Roles { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Validate the user password
                if (await Secrets.Validate(model.UserName, model.Password))
                {
                    string userId = await Logins.GetUserId(IdentityConfig.LocalLoginProvider, model.UserName);
                    await SignIn(userId, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError(String.Empty, "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Create a profile, password, and link the local login before signing in the user
                    User user = new User(model.UserName);
                    if (await Users.Create(user) &&
                        await Secrets.Create(new UserSecret(model.UserName, model.Password)) &&
                        await Logins.Add(new UserLogin(user.Id, IdentityConfig.LocalLoginProvider, model.UserName)))
                    {
                        await SignIn(user.Id, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "Failed to create login for: " + model.UserName);
                    }
                }
                catch (DbEntityValidationException e)
                {
                    ModelState.AddModelError("", e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        {
            ManageMessageId? message = null;
            string userId = User.Identity.GetUserId();
            if (await UnlinkAccountForUser(userId, loginProvider, providerKey))
            {
                // If you remove a local login, need to delete the login as well
                if (loginProvider == IdentityConfig.LocalLoginProvider)
                {
                    await Secrets.Delete(providerKey);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage
        public async Task<ActionResult> Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : String.Empty;
            string localUserName = await Logins.GetProviderKey(User.Identity.GetUserId(), IdentityConfig.LocalLoginProvider);
            ViewBag.UserName = localUserName;
            ViewBag.HasLocalPassword = localUserName != null;
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Manage(ManageUserViewModel model)
        {
            string userId = User.Identity.GetUserId();
            string localUserName = await Logins.GetProviderKey(User.Identity.GetUserId(), IdentityConfig.LocalLoginProvider);
            bool hasLocalLogin = localUserName != null;
            ViewBag.HasLocalPassword = hasLocalLogin;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalLogin)
            {               
                if (ModelState.IsValid)
                {
                    bool changePasswordSucceeded = await ChangePassword(localUserName, model.OldPassword, model.NewPassword);
                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError(String.Empty, "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        // Create the local login info and link the local account to the user
                        localUserName = User.Identity.GetUserName();
                        if (await Secrets.Create(new UserSecret(localUserName, model.NewPassword)) &&
                            await Logins.Add(new UserLogin(userId, IdentityConfig.LocalLoginProvider, localUserName)))
                        {
                            return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                        }
                        else
                        {
                            ModelState.AddModelError(String.Empty, "Failed to set password");
                        }
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError(String.Empty, e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { loginProvider = provider, ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string loginProvider, string returnUrl)
        {
            // Get the information about the user from the external login provider
            ClaimsIdentity id = await HttpContext.GetExternalIdentity();
            if (id == null)
            {
                return View("ExternalLoginFailure");
            }

            // Make sure the external identity is from the loginProvider we expect
            Claim providerKeyClaim = id.FindFirst(ClaimTypes.NameIdentifier);
            if (providerKeyClaim == null || providerKeyClaim.Issuer != loginProvider) {
                return View("ExternalLoginFailure");
            }

            // Succeeded so we should be able to lookup the local user name and sign them in
            string providerKey = providerKeyClaim.Value;
            string userId = await Logins.GetUserId(loginProvider, providerKey);
            if (!String.IsNullOrEmpty(userId))
            {
                await SignIn(userId, id.Claims, isPersistent: false);
            }
            else
            {
                // No local user for this account
                if (User.Identity.IsAuthenticated)
                {
                    // If the current user is logged in, just add the new account
                    await Logins.Add(new UserLogin(User.Identity.GetUserId(), loginProvider, providerKey));
                }
                else
                {
                    ViewBag.ReturnUrl = returnUrl;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = id.Name, LoginProvider = loginProvider });
                }
            }

            return RedirectToLocal(returnUrl);
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Manage");
            }
            
            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                ClaimsIdentity id = await HttpContext.GetExternalIdentity();
                if (id == null)
                {
                    return View("ExternalLoginFailure");
                }
                try
                {
                    // Create a local user and sign in
                    var user = new User(model.UserName);
                    if (await Users.Create(user) &&
                        await Logins.Add(new UserLogin(user.Id, model.LoginProvider, id.FindFirstValue(ClaimTypes.NameIdentifier))))
                    {
                        await SignIn(user.Id, id.Claims, isPersistent: false);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return View("ExternalLoginFailure");
                    }
                }
                catch (DbEntityValidationException e)
                {
                    ModelState.AddModelError("", e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
                }
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return (ActionResult)PartialView("_ExternalLoginsListPartial", new List<AuthenticationDescription>(HttpContext.GetExternalAuthenticationTypes()));
        }


        [ChildActionOnly]
        public ActionResult RemoveAccountList()
        {
            return Task.Run(async () =>
            {
                var linkedAccounts = await Logins.GetLogins(User.Identity.GetUserId());
                ViewBag.ShowRemoveButton = linkedAccounts.Count > 1;
                return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
            }).Result;
        }
       
        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private async Task<bool> UnlinkAccountForUser(string userId, string loginProvider, string providerKey)
        {
            string ownerAccount = await Logins.GetUserId(loginProvider, providerKey);
            if (ownerAccount == userId)
            {
                if ((await Logins.GetLogins(userId)).Count > 1)
                {
                    await Logins.Remove(userId, loginProvider, providerKey);
                    return true;
                }
            }
            return false;
        }

        private async Task<bool> ChangePassword(string userName, string oldPassword, string newPassword)
        {
            bool changePasswordSucceeded = false;
            if (await Secrets.Validate(userName, oldPassword))
            {
                changePasswordSucceeded = await Secrets.UpdateSecret(userName, newPassword);
            }
            return changePasswordSucceeded;
        }

        private Task SignIn(string userId, bool isPersistent)
        {
            return SignIn(userId, new Claim[0], isPersistent);
        }

        private async Task SignIn(string userId, IEnumerable<Claim> claims, bool isPersistent)
        {
            User user = await Users.Find(userId) as User;
            if (user != null)
            {
                // Replace UserIdentity claims with the application specific claims
                IList<Claim> userClaims = IdentityConfig.RemoveUserIdentityClaims(claims);
                IdentityConfig.AddUserIdentityClaims(userId, user.UserName, userClaims);
                IdentityConfig.AddRoleClaims(await Roles.GetRolesForUser(userId), userClaims);
                IdentityConfig.SignIn(HttpContext, userClaims, isPersistent);
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUrl)
            {
                LoginProvider = provider;
                RedirectUrl = redirectUrl;
            }

            public string LoginProvider { get; set; }
            public string RedirectUrl { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                context.HttpContext.Challenge(LoginProvider, new AuthenticationExtra() { RedirectUrl = RedirectUrl });
            }
        }
        
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }
        
        #endregion
    }
}
