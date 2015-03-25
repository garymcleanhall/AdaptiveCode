using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using UI.AspNetWebForms.Models.IdentityModels;


namespace UI.AspNetWebForms
{
   // For more information on ASP.NET Identity, please visit http://go.microsoft.com/fwlink/?LinkId=301882
    public static class IdentityConfig
    {
        public const string LocalLoginProvider = "Local";

        public static UserLoginStoreSync Logins { get; set; }
        public static UserStoreSync Users { get; set; }
        public static UserSecretStoreSync Secrets { get; set; }
        public static RoleStoreSync Roles { get; set; }
        public static string RoleClaimType { get; set; }
        public static string UserNameClaimType { get; set; }
        public static string UserIdClaimType { get; set; }
        public static string ClaimsIssuer { get; set; }

        public static void ConfigureIdentity()
        {
            Logins = new UserLoginStoreSync(new EFUserLoginStore<UserLogin>(new DbContextFactory<IdentityDbContext>()));
            Users = new UserStoreSync(new EFUserStore<User>(new DbContextFactory<IdentityDbContext>()));
            Secrets = new UserSecretStoreSync(new EFUserSecretStore<UserSecret>(new DbContextFactory<IdentityDbContext>()));
            Roles = new RoleStoreSync(new EFRoleStore<Role, UserRole>(new DbContextFactory<IdentityDbContext>()));
            RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
            UserIdClaimType = "http://schemas.microsoft.com/aspnet/userid";
            UserNameClaimType = "http://schemas.microsoft.com/aspnet/username";
            ClaimsIssuer = ClaimsIdentity.DefaultIssuer;
        }

        public static IList<Claim> RemoveUserIdentityClaims(IEnumerable<Claim> claims)
        {
            List<Claim> filteredClaims = new List<Claim>();
            foreach (var c in claims)
            {
                // Strip out any existing name/nameid claims
                if (c.Type != ClaimTypes.Name &&
                    c.Type != ClaimTypes.NameIdentifier)
                {
                    filteredClaims.Add(c);
                }
            }
            return filteredClaims;
        }

        public static void AddRoleClaims(IEnumerable<string> roles, IList<Claim> claims)
        {
            foreach (string role in roles)
            {
                claims.Add(new Claim(RoleClaimType, role, ClaimsIssuer));
            }
        }

        public static void AddUserIdentityClaims(string userId, string userName, IList<Claim> claims)
        {
            claims.Add(new Claim(ClaimTypes.Name, userName, ClaimsIssuer));
            claims.Add(new Claim(UserIdClaimType, userId, ClaimsIssuer));
            claims.Add(new Claim(UserNameClaimType, userName, ClaimsIssuer));
        }

        public static void SignIn(HttpContext context, IEnumerable<Claim> userClaims, bool isPersistent)
        {
            context.SignIn(userClaims, UserNameClaimType, RoleClaimType, isPersistent);
        }

        private const string ProviderNameKey = "providerName";
        public static string GetProviderNameFromRequest(HttpRequest request)
        {
            return request[ProviderNameKey];
        }

        public static string GetExternalLoginRedirectUrl(string accountProvider)
        {
            return "/Account/RegisterExternalLogin?" + ProviderNameKey + "=" + accountProvider;
        }

        public static void SignIn(this HttpContext context, string userId, IEnumerable<Claim> claims, bool isPersistent)
        {
            User user = Users.Find(userId) as User;
            if (user != null)
            {
                IList<Claim> userClaims = RemoveUserIdentityClaims(claims);
                AddUserIdentityClaims(userId, user.UserName, userClaims);
                AddRoleClaims(Roles.GetRolesForUser(userId), userClaims);
                SignIn(context, userClaims, isPersistent);
            }
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
        #region framework extensions should be gone
        public static async Task<ClaimsIdentity> GetExternalIdentity(this HttpContext context)
        {
            return await context.Authenticate(Microsoft.Owin.Security.Forms.FormsAuthenticationDefaults.ExternalAuthenticationType);
        }
        #endregion
    }
}

namespace Microsoft.AspNet.Identity
{
    public static class IdentityExtensions
    {
        public static string GetUserName(this IIdentity identity)
        {
            return identity.Name;
        }

        public static string GetUserId(this IIdentity identity)
        {
            ClaimsIdentity ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue(UI.AspNetWebForms.IdentityConfig.UserIdClaimType);
            }
            return "";
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            Claim claim = identity.FindFirst(claimType);
            if (claim != null)
            {
                return claim.Value;
            }
            return null;
        }

    }
}