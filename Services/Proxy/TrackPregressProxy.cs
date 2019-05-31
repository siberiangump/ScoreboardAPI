using Microsoft.Extensions.Configuration;
using core.Abstractions;
using core.Interfaces;
using core.Models;

namespace core.Services.Proxy
{
    public sealed class TrackPregressProxy : AbstractMongoCollectionProxy<TrackProgress>
    {
        protected override string GetCollectionName() => "TrackPregress";

        public TrackPregressProxy(IMongoConnector connector, IConfiguration config) : base(connector, config) {}
    }
}
