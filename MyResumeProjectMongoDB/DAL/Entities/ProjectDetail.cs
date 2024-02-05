using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyResumeProjectMongoDB.DAL.Entities
{
    public class ProjectDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectDetailID { get; set; }
        public string Project1 { get; set; }
        public string ProjectCount1 { get; set; }
        public string Project2 { get; set; }
        public string ProjectCount2 { get; set; }
    }
}
