using Domain.Attributes;
using Domain.Common;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Documents
{
    [BsonCollection("todo-list")]
    public class TodoList : Document
    {
        public string Name { get; set; }

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public ICollection<TodoItem> Items { get; set; }
    }

    public class TodoItem
    {
        public string Name { get; set; }
    }
}
