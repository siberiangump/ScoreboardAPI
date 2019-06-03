using core.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using core.Abstractions;
using core.Interfaces;
using core.Models;

namespace RaceGameModule.Proxy
{
    public sealed class AccountProxy : AbstractMongoCollectionProxy<Account>
    {
        protected override string GetCollectionName() => "Account";

        public AccountProxy(IMongoConnector connector, IConfiguration config) : base(connector, config) {}
    }
}
