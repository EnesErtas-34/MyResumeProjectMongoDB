using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyResumeProjectMongoDB.DAL.Entities
{
    public class MyProject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MyProjectID { get; set; }
        public string ImageURL { get; set; }
    }
}
