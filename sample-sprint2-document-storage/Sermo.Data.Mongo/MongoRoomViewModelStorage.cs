using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sermo.Data.Contracts;
using Sermo.UI.Contracts;

using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Sermo.Data.Mongo
{
    public class MongoRoomViewModelStorage : IRoomViewModelReader, IRoomViewModelWriter
    {
        public MongoRoomViewModelStorage(IApplicationSettings applicationSettings)
        {
            this.applicationSettings = applicationSettings;
        }

        public IEnumerable<RoomViewModel> GetAllRooms()
        {
            var roomsCollection = GetRoomsCollection();
            return roomsCollection.FindAll();
        }

        public void CreateRoom(RoomViewModel roomViewModel)
        {
            var roomsCollection = GetRoomsCollection();
            roomsCollection.Save(roomViewModel);
        }

        public IEnumerable<MessageViewModel> GetRoomMessages(int roomID)
        {
            var messageQuery = Query<MessageViewModel>.EQ(viewModel => viewModel.RoomID, roomID);
            var messagesCollection = GetMessagesCollection();
            return messagesCollection.Find(messageQuery);
        }

        public void AddMessage(MessageViewModel messageViewModel)
        {
            var messagesCollection = GetMessagesCollection();
            messagesCollection.Save(messageViewModel);
        }

        private MongoCollection<MessageViewModel> GetMessagesCollection()
        {
            var database = GetDatabase();
            var messagesCollection = database.GetCollection<MessageViewModel>(MessagesCollection);
            return messagesCollection;
        }

        private MongoCollection<RoomViewModel> GetRoomsCollection()
        {
            var database = GetDatabase();
            var roomsCollection = database.GetCollection<RoomViewModel>(RoomsCollection);
            return roomsCollection;
        }

        private MongoDatabase GetDatabase()
        {
            var connectionString = applicationSettings.GetValue(MongoConnectionString);
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            return server.GetDatabase(SermoDatabase);
        }

        private readonly IApplicationSettings applicationSettings;
        private static string MongoConnectionString = "MongoConnectionString";
        private static string SermoDatabase = "Sermo";
        private static string MessagesCollection = "messages";
        private static string RoomsCollection = "rooms";
    }
}
