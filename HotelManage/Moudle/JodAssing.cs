using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace HotelManage.Moudle
{
    public class JodAssing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        public string Ename { get; set; }
        public string Joddescription { get; set; }
        public string roomenumber { get; set; }
    }
}
