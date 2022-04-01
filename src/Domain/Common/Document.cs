using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Common
{
    public abstract class Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
