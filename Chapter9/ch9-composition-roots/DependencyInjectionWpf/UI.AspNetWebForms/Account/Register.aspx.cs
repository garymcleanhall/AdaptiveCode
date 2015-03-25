using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Claims;
using System.Web.UI;
using UI.AspNetWebForms.Models.IdentityModels;

namespace UI.AspNetWebForms.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            try
            {
                User u = new User(userName) { UserName = userName };
                IdentityConfig.Users.Create(u);
                IdentityConfig.Secrets.Create(new UserSecret(userName, Password.Text));
                IdentityConfig.Logins.Add(new UserLogin(u.Id, IdentityConfig.LocalLoginProvider, userName));
                Context.SignIn(u.Id, new Claim[] { }, isPersistent: false);
                IdentityConfig.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            catch (DbEntityValidationException ex)
            {
                ErrorMessage.Text = "User name already exists:" + ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
            }
        }
    }
}