using HotelManage.Moudle;
using HotelManage.Serivice;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HotelManage.Repositery
{
    public class JodAssingRepositery : Ijodassingcs
    {
        private readonly IMongoCollection<JodAssing> _hotelCollection;
        public JodAssingRepositery(IOptions<databasesetings> dbseting, IMongoClient mongoClient)
        {

            var database = mongoClient.GetDatabase(dbseting.Value.DatabaseName);
            _hotelCollection = database.GetCollection<JodAssing>(dbseting.Value.JobassinCollectionName);


        }

        public async Task creatAsync(JodAssing jods) =>
               await _hotelCollection.InsertOneAsync(jods);

        public async Task deletebyid(string id) =>
             await _hotelCollection.DeleteOneAsync(a => a.Id == id);


        public async Task<IEnumerable<JodAssing>> GetAllAsyc() =>
           await _hotelCollection.Find(_ => true).ToListAsync();



        public async Task<JodAssing> GetById(string id) =>
          await _hotelCollection.Find(a => a.Id == id).FirstOrDefaultAsync();


        public async Task Updatecatogry(string id, JodAssing jods) =>
            await _hotelCollection.ReplaceOneAsync(op => op.Id == id, jods);

      
       
    }
}

