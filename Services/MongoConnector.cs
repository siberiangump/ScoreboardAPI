using Scoreboard.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Scoreboard.Services
{
    public class MongoConnector: IMongoConnector
    {
        MongoClient IMongoConnector.GetClient() => Client;
        IMongoDatabase IMongoConnector.GetDatabase() => Database;

        private readonly MongoClient Client;
        private readonly IMongoDatabase Database;

        public MongoConnector(IConfiguration config)
        {
            Client = new MongoClient(config.GetConnectionString("mongo_remout_url"));
            Database = Client.GetDatabase(config.GetConnectionString("mongo_remout_database"));
        }
    }
}
