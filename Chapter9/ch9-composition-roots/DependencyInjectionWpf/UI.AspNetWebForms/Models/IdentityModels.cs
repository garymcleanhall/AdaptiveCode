using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace UI.AspNetWebForms.Models.IdentityModels
{
    public class User : IUser
    {
        public User()
            : this("")
        {
        }

        public User(string userName)
        {
            UserName = userName;
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }
    }

    public class UserLogin : IUserLogin
    {
        [Key, Column(Order = 0)]
        public string LoginProvider { get; set; }
        [Key, Column(Order = 1)]
        public string ProviderKey { get; set; }

        public string UserId { get; set; }

        public UserLogin() { }

        public UserLogin(string userId, string providerName, string providerAccountKey)
        {
            LoginProvider = providerName;
            ProviderKey = providerAccountKey;
            UserId = userId;
        }
    }

    public class UserSecret : IUserSecret
    {
        public UserSecret()
        {
        }

        public UserSecret(string userName, string secret)
        {
            UserName = userName;
            Secret = secret;
        }

        [Key]
        public string UserName { get; set; }
        public string Secret { get; set; }
    }

    public class Role : IRole
    {
        public Role()
            : this("")
        {
        }

        public Role(string roleName)
        {
            Id = roleName;
        }

        [Key]
        public string Id { get; set; }
    }

    public class UserRole : IUserRole
    {
        [Key, Column(Order = 0)]
        public string RoleId { get; set; }
        [Key, Column(Order = 1)]
        public string UserId { get; set; }
    }

    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext()
            : base("DefaultConnection")
        {
        }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (entityEntry.State == EntityState.Added)
            {
                User user = entityEntry.Entity as User;
                //check for uniqueness of user name
                if (user != null && Users.Where(u => u.UserName.ToUpper() == user.UserName.ToUpper()).Count() > 0)
                {
                    var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
                    result.ValidationErrors.Add(new DbValidationError("User", "UserName must be unique."));
                    return result;
                }
            }
            return base.ValidateEntity(entityEntry, items);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> Logins { get; set; }
        public DbSet<UserSecret> Secrets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}