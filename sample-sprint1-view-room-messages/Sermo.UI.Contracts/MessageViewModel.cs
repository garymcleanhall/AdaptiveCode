using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sermo.UI.Contracts
{
    public class MessageViewModel
    {
        public long ID
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        public string AuthorName
        {
            get;
            set;
        }
    }
}
