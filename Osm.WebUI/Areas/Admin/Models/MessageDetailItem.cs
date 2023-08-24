namespace Osm.WebUI.Areas.Admin.Models
{
    public class Data
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Subject { get; set; }
        public string Messages { get; set; }
    }

    public class MessageRoot
    {
        public Data data { get; set; }
        public object errorMessage { get; set; }
    }
}
