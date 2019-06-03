using Scoreboard.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace Scoreboard.Abstractions
{
    public abstract class AbstractMongoCollectionProxy<T>  where T: IModel
    {
        protected readonly IMongoCollection<T> Collection;

        protected abstract string GetCollectionName();

        public AbstractMongoCollectionProxy(IMongoConnector connector,IConfiguration config)
        {
            var database = connector.GetDatabase();
            Collection = database.GetCollection<T>(this.GetCollectionName());
        }

        public List<T> Get()
        {
            return Collection.Find(item => true).ToList();
        }

        public T Get(string id)
        {
            return Collection.Find<T>(item => item.Id == id).FirstOrDefault();
        }

        public T Create(T item)
        {
            Collection.InsertOne(item);
            return item;
        }

        public void Update(string id, T itemIn)
        {
            Collection.ReplaceOne(item => item.Id == id, itemIn);
        }

        public void Remove(T itemIn)
        {
            Collection.DeleteOne(item => item.Id == itemIn.Id);
        }

        public void Remove(string id)
        {
            Collection.DeleteOne(item => item.Id == id);
        }
    }
}
