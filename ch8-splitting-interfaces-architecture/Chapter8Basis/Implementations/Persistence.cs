using Interfaces;
using Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementations
{
    public class Persistence : IPersistence
    {
        private readonly ISession session;
        private readonly MongoDatabase mongo;

        public Persistence(ISession session, MongoDatabase mongo)
        {
            this.session = session;
            this.mongo = mongo;
        }

        public IEnumerable<Item> GetAll()
        {
            return mongo.GetCollection<Item>("items").FindAll();
        }

        public Item GetByID(Guid identity)
        {
            return mongo.GetCollection<Item>("items").FindOneById(identity.ToBson());
        }

        public IEnumerable<Item> FindByCriteria(string criteria)
        {
            var query = BsonSerializer.Deserialize<QueryDocument>(criteria);
            return mongo.GetCollection<Item>("Items").Find(query);
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
