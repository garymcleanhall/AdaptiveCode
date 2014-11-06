using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sermo.Data.Contracts;
using Sermo.UI.Contracts;


namespace Sermo.Infrastructure.Contracts
{
    public class SimpleRoomViewModelMapper : IRoomViewModelMapper
    {
        public RoomViewModel MapRoomRecordToRoomViewModel(RoomRecord roomRecord)
        {
            return new RoomViewModel { Name = roomRecord.Name };
        }

        public MessageViewModel MapMessageRecordToMessageViewModel(MessageRecord messageRecord)
        {
            return new MessageViewModel { Text = messageRecord.Text, AuthorName = messageRecord.AuthorName };
        }
    }
}
