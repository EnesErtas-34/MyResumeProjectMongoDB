using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyResumeProjectMongoDB.DAL.Entities
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SkillID { get; set; }
        public string SkillName { get; set; }
        public string Progress { get; set; }
    }
}
