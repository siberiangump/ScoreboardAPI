using Microsoft.Extensions.Configuration;
using core.Abstractions;
using core.Interfaces;
using core.Models;
using System.Collections.Generic;
using MongoDB.Driver;

namespace RaceGameModule.Proxy
{
    public sealed class TrackPregressProxy : AbstractMongoCollectionProxy<TrackProgress>
    {
        protected override string GetCollectionName() => "TrackPregress";

        public TrackPregressProxy(IMongoConnector connector, IConfiguration config) : base(connector, config) { }

        public List<TrackProgress> FindAllByAccountId(string accountId)
        {
            return Collection.Find(item => item.AccountId == accountId).ToList();
        }
    }
}
