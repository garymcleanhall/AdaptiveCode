using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersistenceCommands
    {
        void Save(Item item);

        void Delete(Item item);
    }
}
