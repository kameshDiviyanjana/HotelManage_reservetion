using HotelManage.Moudle;
using HotelManage.Serivice;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotelManage.Repositery
{
    public class HotelseriveRepositer : IHotelseriveRepositer
    {
        private readonly IMongoCollection<Hotel> _hotelCollection;
        public HotelseriveRepositer(IOptions<databasesetings> dbseting, IMongoClient mongoClient) {

            var database = mongoClient.GetDatabase(dbseting.Value.DatabaseName);
            _hotelCollection = database.GetCollection<Hotel>(dbseting.Value.HotelCollectionName);

        
        }
        public async Task creatAsync(Hotel hotel)=>
            await _hotelCollection.InsertOneAsync(hotel);
        

        public async Task  deletebyid(string id) =>
             await _hotelCollection.DeleteOneAsync(a => a.Id == id);


       public  async Task<IEnumerable<Hotel>> GetAllAsyc()=>
            await _hotelCollection.Find(_=>true).ToListAsync();

      

      public async Task<Hotel> GetById(string id)=>
            await _hotelCollection.Find(a => a.Id == id).FirstOrDefaultAsync();


        public async Task Updatecatogry(string id, Hotel hotel) =>
            await _hotelCollection.ReplaceOneAsync(op => op.Id == id, hotel);


        public async Task<Hotel> serchrequest(string idOrName)
        {
            var filter = Builders<Hotel>.Filter.Or(
                Builders<Hotel>.Filter.Eq(h => h.phoneNumber, idOrName),
                Builders<Hotel>.Filter.Eq(h => h.Name, idOrName),
                 Builders<Hotel>.Filter.Eq(h => h.Dateonlyend, idOrName),
                  Builders<Hotel>.Filter.Eq(h => h.Dateonly, idOrName)
            );

            return await _hotelCollection.Find(filter).FirstOrDefaultAsync();
        }

       
    }

}
