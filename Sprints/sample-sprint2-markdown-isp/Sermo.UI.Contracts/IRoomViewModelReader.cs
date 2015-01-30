using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.UI.Contracts
{
    public interface IRoomViewModelReader
    {
        IEnumerable<RoomViewModel> GetAllRooms();

        IEnumerable<MessageViewModel> GetRoomMessages(int roomID);
    }
}
