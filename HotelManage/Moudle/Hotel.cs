using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace HotelManage.Moudle
{
    public class Hotel
    {
        
       [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        public String Name { get; set; }

        public String addres {  get; set; }

        public String phoneNumber
        {
            get; set;
        }

        public String Dateonlyend { get; set; }
//
       // [BsonRepresentation(BsonType.DateOnly)] // Specify the BSON representation
        public String Dateonly { get; set; }

        public String location { get; set; }

        public String Status { get; set; }
        public String priority { get; set; }

        public String packeage { get; set; }




   

    }
}
