using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPersistenceQueries
    {
        IEnumerable<Item> GetAll();

        Item GetByID(Guid identity);

        IEnumerable<Item> FindByCriteria(string criteria);
    }
}
