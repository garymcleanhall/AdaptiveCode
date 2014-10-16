using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NHibernate;

using Model;
using Interfaces;

namespace Implementations
{
    public class PersistenceCommands : IPersistenceCommands
    {
        private readonly ISession session;
        public PersistenceCommands(ISession session)
        {
            this.session = session;
        }

        public void Save(Item item)
        {
            using(var transaction = session.BeginTransaction())
            {
                session.Save(item);

                transaction.Commit();
            }
        }

        public void Delete(Item item)
        {
            using(var transaction = session.BeginTransaction())
            {
                session.Delete(item);

                transaction.Commit();
            }
        }
    }
}
