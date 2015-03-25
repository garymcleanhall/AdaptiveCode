using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace UI.AspNetWebForms.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                if (IdentityConfig.Secrets.Validate(UserName.Text, Password.Text))
                {
                    string localUserId = IdentityConfig.Logins.GetUserId(IdentityConfig.LocalLoginProvider, UserName.Text);
                    if (localUserId != null)
                    {
                        Context.SignIn(localUserId, new Claim[] { }, RememberMe.Checked);
                        IdentityConfig.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    };
                }
                else
                {
                    FailureText.Text = "Your login attempt was not successful. Please try again.";
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}