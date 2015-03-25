using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sermo.Data.Contracts;
using Sermo.UI.Contracts;

namespace Sermo.Infrastructure.Contracts
{
    public interface IViewModelMapper
    {
        RoomViewModel MapRoomRecordToRoomViewModel(RoomRecord roomRecord);
        RoomRecord MapRoomViewModelToRoomRecord(RoomViewModel roomViewModel);
        
        MessageViewModel MapMessageRecordToMessageViewModel(MessageRecord messageRecord);
        MessageRecord MapMessageViewModelToMessageRecord(MessageViewModel messageViewModel);
    }
}
