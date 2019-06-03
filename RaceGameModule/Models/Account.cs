using Scoreboard.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RaceGameModule.Models
{
    public class Account : AbstractMongoModel
    {
        public Account() { }

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Empty")]
        public bool Empty { get; set; }
        [BsonElement("FaceId")]
        public int FaceId { get; set; }
        [BsonElement("Car")]
        public string Car { get; set; }
        [BsonElement("CarVariant")]
        public int CarVariant { get; set; }
    }
}