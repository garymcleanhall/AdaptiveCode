using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UI.AspNetWebForms.Models.IdentityModels;

namespace UI.AspNetWebForms.Account
{
      public partial class RegisterExternalLogin : System.Web.UI.Page
    {
        protected string ProviderName
        {
            get { return (string)ViewState["ProviderName"] ?? String.Empty; }
            private set { ViewState["ProviderName"] = value; }
        }

        protected string ProviderAccountKey
        {
            get { return (string)ViewState["ProviderAccountKey"] ?? String.Empty; }
            private set { ViewState["ProviderAccountKey"] = value; }
        }

        protected void Page_Load()
        {
            // Process the result from an auth provider in the request
            ProviderName = IdentityConfig.GetProviderNameFromRequest(Request);

            if (String.IsNullOrEmpty(ProviderName))
            {
                Response.Redirect("~/Account/Login");
            }

            if (!IsPostBack)
            {
                RegisterAsyncTask(new System.Web.UI.PageAsyncTask(RegisterExternalLoginAsync));
            }
        }        
        
        protected void LogIn_Click(object sender, EventArgs e)
        {
            CreateAndLoginUser();
        }

        private void CreateAndLoginUser()
        {
            if (!IsValid)
            {
                return;
            }

            RegisterAsyncTask(new System.Web.UI.PageAsyncTask(CreateAndLoginUserAsync));
        }

        private async Task RegisterExternalLoginAsync()
        {
            ClaimsIdentity id = await Context.GetExternalIdentity();
            if (id == null)
            {
                ModelState.AddModelError(String.Empty, "There was an error processing this request.");
                return;
            }

            // Make sure the external identity is from the loginProvider we expect
            Claim providerKeyClaim = id.FindFirst(ClaimTypes.NameIdentifier);
            if (providerKeyClaim == null || providerKeyClaim.Issuer != ProviderName) 
            {
                ModelState.AddModelError(String.Empty, "There was an error processing this request.");
                return;
            }

            // Succeeded so we should be able to lookup the local user name and sign them in
            ProviderAccountKey = providerKeyClaim.Value;
            string localUserName = IdentityConfig.Logins.GetUserId(ProviderName, ProviderAccountKey);
            if (!String.IsNullOrEmpty(localUserName))
            {
                Context.SignIn(localUserName, id.Claims, isPersistent: false);
                IdentityConfig.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                // No local user for this account
                if (User.Identity.IsAuthenticated)
                {
                    // If the current user is logged in, just add the new account
                    IdentityConfig.Logins.Add(new UserLogin(User.Identity.GetUserId(), ProviderName, ProviderAccountKey));
                    IdentityConfig.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    userName.Text = id.Name;
                }
            }
        }

        private async Task CreateAndLoginUserAsync()
        {
            ClaimsIdentity id = await Context.GetExternalIdentity();
            if (id == null)
            {
                ModelState.AddModelError(String.Empty, "There was an error processing this request.");
                return;
            }

            try
            {
                var user = new User(userName.Text);
                if (IdentityConfig.Users.Create(user))
                {
                    IdentityConfig.Logins.Add(new UserLogin(user.Id, ProviderName, ProviderAccountKey));
                    Context.SignIn(user.Id, id.Claims, isPersistent: false);
                    IdentityConfig.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
            }
            catch (DbEntityValidationException e)
            {
                ModelState.AddModelError("", e.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage);
            }
        }
    }
}