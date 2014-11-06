using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.Data.Contracts
{
    public interface IRoomRepository
    {
        void CreateRoom(string name);

        IEnumerable<RoomRecord> GetAllRooms();
    }
}
