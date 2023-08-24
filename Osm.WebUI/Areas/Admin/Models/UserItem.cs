namespace Osm.WebUI.Areas.Admin.Models
{
    public class UserData
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class UserRoot
    {
        public UserData data { get; set; }
    }
}
