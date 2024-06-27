using HotelManage.Moudle;

namespace HotelManage.Repositery
{
    public interface Ijodassingcs
    {
        Task<IEnumerable<JodAssing>> GetAllAsyc();

        Task deletebyid(String id);

        Task Updatecatogry(String id, JodAssing hotel);

        Task<JodAssing> GetById(String id);
        Task creatAsync(JodAssing hotel);
    }
}
