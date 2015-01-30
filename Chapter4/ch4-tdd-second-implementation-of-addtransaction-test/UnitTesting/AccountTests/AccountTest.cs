using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerAccounts;

namespace AccountTests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void AccountsHaveAnOpeningBalanceOfZero()
        {
            // Arrange

            // Act
            var account = new Account();

            // Assert
            Assert.AreEqual(0m, account.Balance);
        }

        [TestMethod]
        public void Adding200TransactionChangesBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(200m);

            // Assert
            Assert.AreEqual(200m, account.Balance);
        }

        [TestMethod]
        public void Adding100TransactionChangesBalance()
        {
            // Arrange
            var account = new Account();

            // Act
            account.AddTransaction(100m);

            // Assert
            Assert.AreEqual(100m, account.Balance);
        }
    }
}
