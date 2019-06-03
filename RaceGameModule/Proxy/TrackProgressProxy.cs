using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using MongoDB.Driver;
using Scoreboard.Abstractions;
using Scoreboard.Interfaces;
using RaceGameModule.Models;

namespace RaceGameModule.Proxy
{
    public sealed class TrackProgressProxy : AbstractMongoCollectionProxy<TrackProgress>
    {
        protected override string GetCollectionName() => "TrackPregress";

        public TrackProgressProxy(IMongoConnector connector, IConfiguration config) : base(connector, config) { }

        public List<TrackProgress> FindAllByAccountId(string accountId)
        {
            return Collection.Find(item => item.AccountId == accountId).ToList();
        }
    }
}
