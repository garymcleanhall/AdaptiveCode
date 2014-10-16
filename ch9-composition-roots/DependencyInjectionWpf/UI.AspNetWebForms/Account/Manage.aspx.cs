using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Security;
using UI.AspNetWebForms.Models.IdentityModels;

namespace UI.AspNetWebForms.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                string localUserName = IdentityConfig.Logins.GetProviderKey(User.Identity.GetUserId(), IdentityConfig.LocalLoginProvider);
                if (localUserName != null)
                {
                    changePasswordHolder.Visible = true;
                    changePasswordUserName.Text = localUserName;
                }
                else
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = IdentityConfig.Logins.GetLogins(User.Identity.GetUserId()).Count > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UserSecret loginInfo = IdentityConfig.Secrets.Find(changePasswordUserName.Text) as UserSecret;
                if (loginInfo == null)
                {
                    FailureText.Text = "Error finding user";
                    return;
                }
                if (!IdentityConfig.Secrets.Validate(changePasswordUserName.Text, CurrentPassword.Text))
                {
                    FailureText.Text = "Current password does not match";
                    return;
                }
                if (IdentityConfig.Secrets.UpdateSecret(changePasswordUserName.Text, NewPassword.Text))
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    FailureText.Text = "Change password failed";
                }
            }
        }


        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                string userName = User.Identity.GetUserName();
                if (IdentityConfig.Secrets.Create(new UserSecret(userName, password.Text)) &&
                    IdentityConfig.Logins.Add(new UserLogin(User.Identity.GetUserId(), IdentityConfig.LocalLoginProvider, userName)))
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    FailureText.Text = "Failed to set password";
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            var accounts = IdentityConfig.Logins.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            var m = IdentityConfig.Logins.Remove(User.Identity.GetUserId(), loginProvider, providerKey)
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            if (loginProvider == IdentityConfig.LocalLoginProvider)
            {
                // Need to delete local user if we are unlinking that
                IdentityConfig.Secrets.Delete(providerKey);
            }
            Response.Redirect("~/Account/Manage" + m);
        }
    }
}