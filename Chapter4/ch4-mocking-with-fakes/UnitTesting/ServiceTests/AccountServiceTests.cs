using System;

using Domain;
using Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceTests
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Account();
            var fakeRepository = new FakeAccountRepository(account);
            var sut = new AccountService(fakeRepository);

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
        }
    }
}
