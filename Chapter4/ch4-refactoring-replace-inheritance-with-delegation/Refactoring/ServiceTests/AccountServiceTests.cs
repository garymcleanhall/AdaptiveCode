using System;

using Domain;
using Domain.Factories;
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
            var accountFactory = new Mock<IAccountFactory>();
            var accountRepository = new Mock<IAccountRepository>();
            var sut = new AccountService(accountFactory.Object, accountRepository.Object);

            // Act
            sut.CreateAccount(RewardCardType.Gold);

            // Assert
            accountRepository.Verify(ar => ar.NewAccount(It.IsAny<Account>()));
        }
    }
}
