using System.Collections.Generic;
using MongoDB.Bson;

namespace createCollections
{
    public class CreateCol {
        public ObjectId Id { get; set; }
        public Dictionary<string, string> CollectionData = new Dictionary<string, string>();
    }

    public class Config {
        public string Url { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }
    }
}
