using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UI.AspNetMvc;
using UI.AspNetMvc.Models;

namespace UI.AspNetMvc
{
    // For more information on ASP.NET Identity, visit http://go.microsoft.com/fwlink/?LinkId=301863
    public static class IdentityConfig 
    {
        public const string LocalLoginProvider = "Local";

        public static IUserSecretStore Secrets { get; set; }
        public static IUserLoginStore Logins { get; set; }
        public static IUserStore Users { get; set; }
        public static IRoleStore Roles { get; set; }
        public static string RoleClaimType { get; set; }
        public static string UserNameClaimType { get; set; }
        public static string UserIdClaimType { get; set; }
        public static string ClaimsIssuer { get; set; }

        public static void ConfigureIdentity() 
        {
            var dbContextCreator = new DbContextFactory<IdentityDbContext>();
            Secrets = new EFUserSecretStore<UserSecret>(dbContextCreator);
            Logins = new EFUserLoginStore<UserLogin>(dbContextCreator);
            Users = new EFUserStore<User>(dbContextCreator);
            Roles = new EFRoleStore<Role, UserRole>(dbContextCreator);
            RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
            UserIdClaimType = "http://schemas.microsoft.com/aspnet/userid";
            UserNameClaimType = "http://schemas.microsoft.com/aspnet/username";
            ClaimsIssuer = ClaimsIdentity.DefaultIssuer;
            AntiForgeryConfig.UniqueClaimTypeIdentifier = IdentityConfig.UserIdClaimType;
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

        public static void AddUserIdentityClaims(string userId, string displayName, IList<Claim> claims) 
        {
            claims.Add(new Claim(ClaimTypes.Name, displayName, ClaimsIssuer));
            claims.Add(new Claim(UserIdClaimType, userId, ClaimsIssuer));
            claims.Add(new Claim(UserNameClaimType, displayName, ClaimsIssuer));
        }

        public static void SignIn(HttpContextBase context, IEnumerable<Claim> userClaims, bool isPersistent) 
        {
            context.SignIn(userClaims, ClaimTypes.Name, RoleClaimType, isPersistent);
        }
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
                return ci.FindFirstValue(UI.AspNetMvc.IdentityConfig.UserIdClaimType);
            }
            return String.Empty;
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