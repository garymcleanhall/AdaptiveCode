using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.UI.Contracts
{
    public class RoomViewModel
    {
        [Required]
        [ContentFiltered]
        public string Name
        {
            get;
            set;
        }
    }
}
