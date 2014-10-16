using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public class TaskDto
    {
        public int ID
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Priority
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public bool Completed
        {
            get;
            set;
        }
    }
}
