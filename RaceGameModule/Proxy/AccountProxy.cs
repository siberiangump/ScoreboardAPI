using Microsoft.Extensions.Configuration;
using RaceGameModule.Models;
using Scoreboard.Abstractions;
using Scoreboard.Interfaces;

namespace RaceGameModule.Proxy
{
    public sealed class AccountProxy : AbstractMongoCollectionProxy<Account>
    {
        protected override string GetCollectionName() => "Account";

        public AccountProxy(IMongoConnector connector, IConfiguration config) : base(connector, config) {}
    }
}
