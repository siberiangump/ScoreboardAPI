using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core.Interfaces
{
    public interface IMongoConnector
    {
        MongoClient GetClient();

        IMongoDatabase GetDatabase();
    }
}
