using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyResumeProjectMongoDB.DAL.Entities
{
    public class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProfileID { get; set; }
        public string NameSurname { get; set; }
        public string ImageURL { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Title3 { get; set; }
        public string? VideoURL { get; set; }
    }
}
