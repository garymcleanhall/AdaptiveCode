using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

using Model;
using Interfaces;

namespace Implementations.MongoDb
{
    public class Persistence : IPersistenceQueries
    {
        private readonly MongoDatabase mongo;

        public Persistence(MongoDatabase mongo)
        {
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
    }
}
