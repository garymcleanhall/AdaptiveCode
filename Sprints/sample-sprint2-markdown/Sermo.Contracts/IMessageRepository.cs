using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.Data.Contracts
{
    public interface IMessageRepository
    {
        IEnumerable<MessageRecord> GetMessagesForRoomID(int roomID);

        void AddMessageToRoom(int roomID, string authorName, string text);
    }
}
