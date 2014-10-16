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
    /// <remarks>
    /// NOTE: These tests will not be runnable, because the `SubtypeCovariance` assembly cannot be built.
    /// C# does not support covariance between subtypes *unless* generics are involved.
    /// </remarks>
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void EntityRepositoryReturnsEntity()
        {
            var entityRepository = new EntityRepository();
            entityRepository.GetByID(Guid.NewGuid())
                .Should().NotBeNull()
                .And.Should().BeOfType<Entity>();
        }

        [Test]
        public void UserRepositoryReturnsUser()
        {
            var userRepository = new UserRepository();
            userRepository.GetByID(Guid.NewGuid())
                .Should().NotBeNull()
                .And.Should().BeOfType<User>();
        }
    }
}
