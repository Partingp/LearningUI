using ExperimentalRestAPI.API.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExperimentalRestAPI.API.Models;
public class Scores
{
    [BsonElement("cuteness")]
    public int Cuteness { get; set; }

    [BsonElement("description")]
    public float Speed { get; set; }

    [BsonElement("thumbnail")]
    public int Mischief { get; set; }

    [BsonElement("lifespan")]
    public int Lifespan { get; set; }

    [BsonElement("pettable")]
    public bool Pettable { get; set; }

    [BsonElement("rarity")]
    public Rarity Rarity { get; set; }

    [BsonElement("overall")]
    public float Overall { get; set; }
}