using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyResumeProjectMongoDB.DAL.Entities
{
	public class Contact
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactID { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
