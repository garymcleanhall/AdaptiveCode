using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sermo.Data.Contracts;
using Sermo.UI.Contracts;

namespace Sermo.Infrastructure.Contracts
{
    public interface IRoomViewModelMapper
    {
        RoomViewModel MapRoomRecordToRoomViewModel(RoomRecord roomRecord);

        MessageViewModel MapMessageRecordToMessageViewModel(MessageRecord messageRecord);
    }
}
