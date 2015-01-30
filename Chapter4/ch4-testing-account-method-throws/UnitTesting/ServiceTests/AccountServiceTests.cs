using System;

using Domain;
using Services;
using RepositoryInterfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace ServiceTests
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotCreateAccountServiceWithNullAccountRepository()
        {
            // Arrange    

            // Act
            new AccountService(null);

            // Assert
        }

        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(200m)).Verifiable();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            account.Verify();
        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IAccountRepository>();
            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 100m);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ServiceException))]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 100m);

            // Assert
        }
    }
}
