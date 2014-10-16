using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SubtypeCovariance;

using NUnit.Framework;
using FluentAssertions;

namespace SubtypeCovarianceTests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void EntityRepositoryReturnsEntity()
        {
            IEntityRepository<Entity> entityRepository = new EntityRepository();
            entityRepository.GetByID(Guid.NewGuid())
                .Should().NotBeNull()
                .And.BeOfType<Entity>();
        }

        /// <remarks>
        /// This test now compiles - and passes - because the generic interface IEntityRepository's TEntity parameter 
        /// is specified as covariant by using the 'out' keyword.
        /// </remarks>
        [Test]
        public void UserRepositoryReturnsUser()
        {
            IEntityRepository<Entity> userRepository = new UserRepository();
            userRepository.GetByID(Guid.NewGuid())
                .Should().NotBeNull()
                .And.BeOfType<User>();
        }
    }
}
