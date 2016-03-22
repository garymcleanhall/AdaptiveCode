using NUnit.Framework;
using SubtypeContravariance;

namespace SubtypeContravarianceTests
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
            // This attempt to save will not compile because 
            // we are treating the user as an `object` instance
            // userRepository.Save(userAsObject);
        }
    }
}
