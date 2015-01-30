using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sermo.UI.Controllers;
using Sermo.Data.Contracts;
using Sermo.Infrastructure.Contracts;

using NUnit.Framework;
using Moq;

namespace Sermo.UnitTests
{
    [TestFixture]
    public class RepositoryRoomViewModelServiceTests
    {
        [Test]
        public void ConstructingWithoutRoomRepositoryThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RepositoryRoomViewModelService(null, mockMessageRepository.Object, mockRoomViewModelMapper.Object));
        }

        [Test]
        public void ConstructingWithoutMessageRepositoryThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RepositoryRoomViewModelService(mockRoomRepository.Object, null, mockRoomViewModelMapper.Object));
        }

        [Test]
        public void ConstructingWithoutServiceThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RepositoryRoomViewModelService(mockRoomRepository.Object, mockMessageRepository.Object, null));
        }

        [Test]
        public void ConstructingWithValidParametersDoesNotThrow()
        {
            Assert.DoesNotThrow(() => CreateService());
        }

        [Test]
        public void GetAllRoomsDelegatesToRoomViewModelMapper()
        {
            var service = CreateService();
            var roomOne = new RoomRecord("Room one");
            var roomTwo = new RoomRecord("Room two");
            var roomThree = new RoomRecord("Room three");
            var rooms = new List<RoomRecord> { roomOne, roomTwo, roomThree };
            mockRoomRepository.Setup(repository => repository.GetAllRooms()).Returns(rooms);

            service.GetAllRooms();

            mockRoomViewModelMapper.Verify(mapper => mapper.MapRoomRecordToRoomViewModel(roomOne));
            mockRoomViewModelMapper.Verify(mapper => mapper.MapRoomRecordToRoomViewModel(roomTwo));
            mockRoomViewModelMapper.Verify(mapper => mapper.MapRoomRecordToRoomViewModel(roomThree));
        }

        [Test]
        public void CreateRoomDelegatesToRepository()
        {
            var service = CreateService();

            service.CreateRoom("Test Room");

            mockRoomRepository.Verify(repository => repository.CreateRoom("Test Room"));
        }

        [Test]
        public void GetRoomMessagesDelegatesToRepository()
        {
            var service = CreateService();

            service.GetRoomMessages(1);

            mockMessageRepository.Verify(repository => repository.GetMessagesForRoomID(1));
        }

        [Test]
        public void GetRoomMessagesDelegatesToRoomViewModelMapper()
        {
            var service = CreateService();
            var messageOne = new MessageRecord(1, "Hello 1.", "David");
            var messageTwo = new MessageRecord(1, "Hello 2.", "Dianne");
            var messageThree = new MessageRecord(1, "Hello3.", "Steve");
            var messages = new List<MessageRecord> { messageOne, messageTwo, messageThree };
            mockMessageRepository.Setup(repository => repository.GetMessagesForRoomID(1)).Returns(messages);

            service.GetRoomMessages(1);

            mockRoomViewModelMapper.Verify(mapper => mapper.MapMessageRecordToMessageViewModel(messageOne));
            mockRoomViewModelMapper.Verify(mapper => mapper.MapMessageRecordToMessageViewModel(messageTwo));
            mockRoomViewModelMapper.Verify(mapper => mapper.MapMessageRecordToMessageViewModel(messageThree));
        }

        [SetUp]
        public void SetUp()
        {
            mockRoomRepository = new Mock<IRoomRepository>();
            mockMessageRepository = new Mock<IMessageRepository>();
            mockRoomViewModelMapper = new Mock<IRoomViewModelMapper>();
        }

        private RepositoryRoomViewModelService CreateService()
        {
            return new RepositoryRoomViewModelService(mockRoomRepository.Object, mockMessageRepository.Object, mockRoomViewModelMapper.Object);
        }

        private Mock<IRoomRepository> mockRoomRepository;
        private Mock<IMessageRepository> mockMessageRepository;
        private Mock<IRoomViewModelMapper> mockRoomViewModelMapper;
    }
}
