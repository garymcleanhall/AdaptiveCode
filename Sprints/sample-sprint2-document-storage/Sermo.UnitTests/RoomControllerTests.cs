using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Routing;

using Sermo.UI.Contracts;
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
        public void ConstructingWithoutReaderThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RoomController(null, mockWriter.Object));
        }

        [Test]
        public void ConstructingWithoutWriterThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RoomController(mockReader.Object, null));
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

            Assert.That(viewResult.Model, Is.InstanceOf<RoomViewModel>());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void PostCreateNewRoomWithInvalidRoomNameCausesValidationError(string roomName)
        {
            var controller = CreateController();

            var viewModel = new RoomViewModel { Name = roomName };

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(viewModel, context, results);

            Assert.That(isValid, Is.False);
        }

        [Test]
        [TestCase("Callooh! Callay! O frabjous day!")]
        [TestCase("The frumious Bandersnatch!")]
        [TestCase("A hefferlump or woozle is very confusel...")]
        public void PostCreateNewRoomWithBlacklistedWordsCausesValidationError(string roomName)
        {
            var controller = CreateController();

            var viewModel = new RoomViewModel { Name = roomName };
            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(viewModel, context, results, true);

            Assert.That(isValid, Is.False);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void PostCreateNewRoomWithInvalidRoomNameShowsCreateView(string roomName)
        {
            var controller = CreateController();

            var viewModel = new RoomViewModel { Name = roomName };
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

            var viewModel = new RoomViewModel { Name = "Test Room" };
            var result = controller.Create(viewModel);

            Assert.That(result, Is.InstanceOf<RedirectToRouteResult>());
            
            var redirectResult = result as RedirectToRouteResult;
            Assert.That(redirectResult.RouteValues["Action"], Is.EqualTo("List"));
        }

        [Test]
        public void PostCreateNewRoomDelegatesToWriter()
        {
            var controller = CreateController();

            var viewModel = new RoomViewModel { Name = "Test Room" };
            controller.Create(viewModel);

            mockWriter.Verify(writer => writer.CreateRoom(viewModel));
        }

        [Test]
        public void GetListRoomsDelegatesToRoomRepository()
        {
            var controller = CreateController();

            controller.List();

            mockReader.Verify(reader => reader.GetAllRooms());
        }

        [Test]
        public void GetListRoomsReturnsRoomListViewModel()
        {
            var controller = CreateController();
            var rooms = new List<RoomViewModel>();
            mockReader.Setup(repository => repository.GetAllRooms()).Returns(rooms);

            var viewResult = controller.List() as ViewResult;

            Assert.That(viewResult.Model, Is.InstanceOf<RoomListViewModel>());

            var model = viewResult.Model as RoomListViewModel;
            Assert.That(model.Rooms, Is.EquivalentTo(rooms));
        }

        [Test]
        public void GetListRoomsReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.List();

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void GetMessagesReturnsViewResult()
        {
            var controller = CreateController();

            var result = controller.Messages(1);

            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void GetMessagesReturnsMessageViewModel()
        {
            var controller = CreateController();

            var viewResult = controller.Messages(1) as ViewResult;

            Assert.That(viewResult.Model, Is.InstanceOf<MessageListViewModel>());
        }

        [Test]
        public void GetMessagesDelegatesToReader()
        {
            var controller = CreateController();

            controller.Messages(1);

            mockReader.Verify(reader => reader.GetRoomMessages(1));
        }

        [Test]
        public void PostAddMessageDelegatesToWriter()
        {
            var controller = CreateController();

            var viewModel = new MessageViewModel { AuthorName = "David", Text = "Hello!" };

            controller.AddMessage(viewModel);

            mockWriter.Verify(writer => writer.AddMessage(viewModel));
        }
        
        [Test]
        public void PostAddMessageReturnsJsonResult()
        {
            var controller = CreateController();

            var viewModel = new MessageViewModel { AuthorName = "David", Text = "Hello!" };

            var result = controller.AddMessage(viewModel);

            Assert.That(result, Is.InstanceOf<JsonResult>());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void PostAddMessageWithInvalidTextCausesValidationError(string text)
        {
            var controller = CreateController();

            var viewModel = new MessageViewModel { AuthorName = "David", Text = text };

            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(viewModel, context, results);

            Assert.That(isValid, Is.False);
        }

        [Test]
        [TestCase("Callooh! Callay! O frabjous day!")]
        [TestCase("The frumious Bandersnatch!")]
        [TestCase("A hefferlump or woozle is very confusel...")]
        public void PostAddMessageWithBlacklistedWordsCausesValidationError(string text)
        {
            var controller = CreateController();

            var viewModel = new MessageViewModel { AuthorName = "David", Text = text};
            var context = new ValidationContext(viewModel, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(viewModel, context, results, true);

            Assert.That(isValid, Is.False);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void PostAddMessageWithInvalidTextReturnsBadRequestStatusCode(string text)
        {
            var controller = CreateController();
            var viewModel = new MessageViewModel { AuthorName = "David", Text = text };
            controller.ViewData.ModelState.AddModelError("Message Text", "The message text field is required.");

            var result = controller.AddMessage(viewModel);

            Assert.That(result, Is.InstanceOf<HttpStatusCodeResult>());

            var httpStatusCodeResult = result as HttpStatusCodeResult;
            Assert.That(httpStatusCodeResult.StatusCode, Is.EqualTo(400));
        }

        [SetUp]
        public void SetUp()
        {
            mockReader = new Mock<IRoomViewModelReader>();
            mockWriter = new Mock<IRoomViewModelWriter>();
        }

        private RoomController CreateController()
        {
            return new RoomController(mockReader.Object, mockWriter.Object);
        }

        private Mock<IRoomViewModelReader> mockReader;
        private Mock<IRoomViewModelWriter> mockWriter;
    }
}
