using MongoDB.Driver;

namespace Scoreboard.Interfaces
{
    public interface IMongoConnector
    {
        MongoClient GetClient();

        IMongoDatabase GetDatabase();
    }
}
