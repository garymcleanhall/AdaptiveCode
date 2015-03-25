using System;

using Domain;
using Domain.Repositories;
using Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace ServiceTests
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        public void CanCreateAGoldAccount()
        {
            // Arrange
            var accountRepository = new Mock<IAccountRepository>();
            var sut = new AccountService(accountRepository.Object);

            // Act
            sut.CreateAccount(AccountType.Gold);

            // Assert
            accountRepository.Verify(ar => ar.NewAccount(It.IsAny<AccountBase>()));
        }
    }
}
