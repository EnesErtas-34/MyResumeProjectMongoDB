using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyResumeProjectMongoDB.DAL.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
        public string Feature3 { get; set; }
    }
}
