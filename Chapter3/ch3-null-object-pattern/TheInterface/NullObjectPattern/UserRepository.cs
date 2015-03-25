using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
            users = new List<User>
            {
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid())
            };
        }

        public IUser GetByID(Guid userID)
        {
            IUser userFound = users.SingleOrDefault(user => user.ID == userID);
            if(userFound == null)
            {
                userFound = new NullUser();
            }
            return userFound;
        }

        private ICollection<User> users;
    }
}
