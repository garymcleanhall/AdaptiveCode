using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sermo.UI.ViewModels
{
    public class CreateRoomViewModel
    {
        [Required]
        public string NewRoomName
        {
            get;
            set;
        }
    }
}