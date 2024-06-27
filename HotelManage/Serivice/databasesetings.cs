namespace HotelManage.Serivice
{
    public class databasesetings : IdatabseconnetinSetings
    {
       public  String? ConnectionString { get; set; }
       public  String? DatabaseName { get; set; }
       public  String? HotelCollectionName { get; set; }
        public String? JobassinCollectionName { get; set; }
    }
}
