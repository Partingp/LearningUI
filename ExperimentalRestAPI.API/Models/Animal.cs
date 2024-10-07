using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExperimentalRestAPI.API.Models;
public class Animal
{
    [BsonId]
    public Guid Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("thumbnail")]
    public string Thumbnail { get; set; }

    [BsonElement("isdomestic")]
    public bool IsDomestic { get; set; }

    [BsonElement("locations")]
    public string[] Locations { get; set; }

    [BsonElement("weight")]
    public float Weight { get; set; }

    [BsonElement("height")]
    public float Height { get; set; }

    [BsonElement("scores")]
    public Scores Scores { get; set; }
}