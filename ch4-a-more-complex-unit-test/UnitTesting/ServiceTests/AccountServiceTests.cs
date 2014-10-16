using System;

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
            var sut = new AccountService();

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            Assert.Fail();
        }
    }
}
