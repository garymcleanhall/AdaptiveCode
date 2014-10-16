using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestOverspecification.Core;
using TestOverspecification.Services;

using NUnit.Framework;

using Moq;

namespace TestOverspecification.Tests
{
    [TestFixture]
    public class LoginControllerFixture
    {
        [Test]
        public void LoginServiceSucceeds_RedirectToMainPage()
        {
            var mockLoginService = new Mock<ILoginService>();
            mockLoginService.Setup(service => service.CheckCredentials(string.Empty, string.Empty)).Returns(true);
            var controller = new LoginController(mockLoginService.Object);

            controller.Login(string.Empty, string.Empty);

            mockLoginService.Verify(service => service.CheckCredentials(string.Empty, string.Empty));
        }

        [Test]
        public void LoginServiceFails_ShowViewWithErrors()
        {

        }
    }
}
