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
            mockAccount.Setup(a => a.AddTransaction(200m)).Verifiable();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(mockAccount.Object);
            
            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            mockAccount.Verify();
        }

        [TestMethod]
        public void DoNotThrowWhenAccountIsNotFound()
        {
            // Act
            sut.AddTransactionToAccount("Trading Account", 100m);

            // Assert
        }

        [TestMethod]
        public void AccountExceptionsAreWrappedInThrowServiceException()
        {
            // Arrange
            mockAccount.Setup(a => a.AddTransaction(100m)).Throws<DomainException>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(mockAccount.Object);

            // Act
            try
            {
                sut.AddTransactionToAccount("Trading Account", 100m);
            }
            catch(ServiceException serviceException)
            {
                // Assert
                Assert.IsInstanceOfType(serviceException.InnerException, typeof(DomainException));
            }
        }
    
        [TestInitialize]
        public void Setup()
        {
            mockAccount = new Mock<Account>();
            mockRepository = new Mock<IAccountRepository>();
            sut = new AccountService(mockRepository.Object);
        }

        private Mock<Account> mockAccount;
        private Mock<IAccountRepository> mockRepository;
        private AccountService sut;
    }
}
