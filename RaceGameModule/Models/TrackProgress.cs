using Scoreboard.Abstractions;

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
