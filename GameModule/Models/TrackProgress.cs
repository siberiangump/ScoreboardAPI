using Scoreboard.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceGameModule.Models
{
    public class TrackProgress : AbstractMongoModel
    {
        public string AccountId { get; set; }
        public string Track { get; set; }
        public float Time { get; set; }
        public string Car { get; set; }
    }
}
