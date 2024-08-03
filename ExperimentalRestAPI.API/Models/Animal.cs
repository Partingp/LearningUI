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
}