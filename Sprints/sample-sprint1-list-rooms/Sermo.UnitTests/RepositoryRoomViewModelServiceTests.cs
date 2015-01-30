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
        public void ConstructingWithoutRepositoryThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RepositoryRoomViewModelService(null, mockRoomViewModelMapper.Object));
        }

        [Test]
        public void ConstructingWithoutServiceThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RepositoryRoomViewModelService(mockRoomRepository.Object, null));
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

        [SetUp]
        public void SetUp()
        {
            mockRoomRepository = new Mock<IRoomRepository>();
            mockRoomViewModelMapper = new Mock<IRoomViewModelMapper>();
        }

        private RepositoryRoomViewModelService CreateService()
        {
            return new RepositoryRoomViewModelService(mockRoomRepository.Object, mockRoomViewModelMapper.Object);
        }

        private Mock<IRoomRepository> mockRoomRepository;
        private Mock<IRoomViewModelMapper> mockRoomViewModelMapper;
    }
}
