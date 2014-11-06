using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sermo.UI.Contracts;

namespace Sermo.UI.ViewModels
{
    public class RoomListViewModel
    {
        public RoomListViewModel(IEnumerable<RoomViewModel> rooms)
        {
            Rooms = new List<RoomViewModel>(rooms);
        }

        public List<RoomViewModel> Rooms
        {
            get;
            private set;
        }
    }
}