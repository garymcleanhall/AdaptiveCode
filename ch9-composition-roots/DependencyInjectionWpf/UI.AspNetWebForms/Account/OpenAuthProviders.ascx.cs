using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace UI.AspNetWebForms.Account
{
    public partial class OpenAuthProviders : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var provider = Request.Form["provider"];
                if (provider == null)
                {
                    return;
                }
                // Request a redirect to the external login provider
                Context.Challenge(new string[] { provider }, new AuthenticationExtra() { RedirectUrl = "/Account/RegisterExternalLogin?providerName=" + provider });
                Response.StatusCode = 401;
                Response.End();
            }
        }

        public string ReturnUrl { get; set; }

        public IEnumerable<string> GetProviderNames()
        {
            return Context.GetExternalAuthenticationTypes().Select(t => t.Properties["AuthenticationType"].ToString());
        }
    }
}