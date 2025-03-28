namespace GoalTrackingAPI.Database.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class Objective
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("userId")]
        public Guid UserId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;
        
        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("occurence")]
        public string Occurence { get; set; }

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("EndDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
