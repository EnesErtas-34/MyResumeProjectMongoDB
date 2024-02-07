using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MyResumeProjectMongoDB.DAL.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
