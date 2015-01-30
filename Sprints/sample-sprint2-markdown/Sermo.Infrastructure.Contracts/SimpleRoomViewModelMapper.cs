using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sermo.Data.Contracts;
using Sermo.UI.Contracts;


namespace Sermo.Infrastructure.Contracts
{
    public class SimpleRoomViewModelMapper : IViewModelMapper
    {
        public RoomViewModel MapRoomRecordToRoomViewModel(RoomRecord roomRecord)
        {
            return new RoomViewModel { Name = roomRecord.Name };
        }

        public RoomRecord MapRoomViewModelToRoomRecord(RoomViewModel roomViewModel)
        {
            return new RoomRecord(roomViewModel.Name);
        }

        public MessageViewModel MapMessageRecordToMessageViewModel(MessageRecord messageRecord)
        {
            return new MessageViewModel { Text = messageRecord.Text, AuthorName = messageRecord.AuthorName };
        }

        public MessageRecord MapMessageViewModelToMessageRecord(MessageViewModel messageViewModel)
        {
            return new MessageRecord(messageViewModel.RoomID, messageViewModel.AuthorName, messageViewModel.Text);
        }
    }
}
