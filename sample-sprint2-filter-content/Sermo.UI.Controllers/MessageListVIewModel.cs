using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sermo.UI.Contracts;

namespace Sermo.UI.ViewModels
{
    public class MessageListViewModel
    {
        public MessageListViewModel(IEnumerable<MessageViewModel> messages)
        {
            Messages = new List<MessageViewModel>(messages);
        }

        public List<MessageViewModel> Messages
        {
            get;
            private set;
        }
    }
}