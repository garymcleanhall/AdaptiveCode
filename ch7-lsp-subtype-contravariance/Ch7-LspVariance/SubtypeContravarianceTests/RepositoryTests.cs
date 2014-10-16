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
    /// NOTE: These tests will not be runnable, because the `SubtypeContravariance` assembly cannot be built.
    /// C# does not support contravariance between subtypes *unless* generics are involved.
    /// </remarks>
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void EntityRepositorySavesEntities()
        {
            var entityRepository = new EntityRepository();
            var entity = new Entity();
            entityRepository.Save(entity);
        }

        [Test]
        public void UserRepositorySavesObjects()
        {
            var userRepository = new UserRepository();
            object userAsObject = new User();
            userRepository.Save(userAsObject);
        }
    }
}
