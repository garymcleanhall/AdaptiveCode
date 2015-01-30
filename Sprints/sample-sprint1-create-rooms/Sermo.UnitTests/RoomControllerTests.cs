using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Routing;

using Sermo.Contracts;
using Sermo.UI.Controllers;
using Sermo.UI.ViewModels;

using NUnit.Framework;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace Sermo.UnitTests
{
    [TestFixture]
    public class RoomControllerTests
    {
        [Test]
        public void ConstructingWithoutRepositoryThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RoomController(null));
        }

        [Test]
        public void ConstructingWithValidParametersDoesNotThrowException()
        {
            Assert.DoesNotThrow(() => CreateController());
        }

        [Test]
        public void GetCreateRendersView()
        {
            var controller = CreateController();

            var result = controller.Create();

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void GetCreateSetsViewModel()
        {
            var controller = CreateController();

            var viewResult = controller.Create() as ViewResult;

            Assert.That(viewResult.Model, Is.InstanceOf<CreateRoomViewModel>());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void PostCreateNewRoomWithInvalidRoomNameCausesValidationError(string roomName)
        {
            var controller = CreateController();

            var viewModel = new CreateRoomViewModel { NewRoomName = roomName };

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(viewModel, context, results);

            Assert.That(isValid, Is.False);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void PostCreateNewRoomWithInvalidRoomNameShowsCreateView(string roomName)
        {
            var controller = CreateController();

            var viewModel = new CreateRoomViewModel { NewRoomName = roomName };
            controller.ViewData.ModelState.AddModelError("Room Name", "Room name is required");
            var result = controller.Create(viewModel);

            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            Assert.That(viewResult.View, Is.Null);
            Assert.That(viewResult.Model, Is.EqualTo(viewModel));
        }

        [Test]
        public void PostCreateNewRoomRedirectsToViewResult()
        {
            var controller = CreateController();

            var viewModel = new CreateRoomViewModel { NewRoomName = "Test Room" };
            var result = controller.Create(viewModel);

            Assert.That(result, Is.InstanceOf<RedirectToRouteResult>());
            
            var redirectResult = result as RedirectToRouteResult;
            Assert.That(redirectResult.RouteValues["Action"], Is.EqualTo("List"));
        }

        [Test]
        public void PostCreateNewRoomDelegatesToRoomRepository()
        {
            var controller = CreateController();

            var viewModel = new CreateRoomViewModel { NewRoomName = "Test Room" };
            controller.Create(viewModel);

            mockRoomRepository.Verify(repository => repository.CreateRoom("Test Room"));
        }

        [SetUp]
        public void SetUp()
        {
            mockRoomRepository = new Mock<IRoomRepository>();
        }

        private RoomController CreateController()
        {
            return new RoomController(mockRoomRepository.Object);
        }

        private Mock<IRoomRepository> mockRoomRepository;
    }
}
