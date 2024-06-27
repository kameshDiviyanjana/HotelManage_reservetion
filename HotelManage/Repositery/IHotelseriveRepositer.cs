using HotelManage.Moudle;

namespace HotelManage.Repositery
{
    public interface IHotelseriveRepositer
    {
        Task<IEnumerable<Hotel>> GetAllAsyc();

        Task deletebyid(String id);

        Task Updatecatogry(String id, Hotel hotel);

        Task<Hotel> GetById(String id);
        Task<Hotel> serchrequest(String id);
        Task creatAsync(Hotel hotel);
    }
}
