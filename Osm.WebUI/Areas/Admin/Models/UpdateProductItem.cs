namespace Osm.WebUI.Areas.Admin.Models
{
    public class DataUpdate
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string descriptionEn { get; set; }
        public int categoryID { get; set; }
        public string? image { get; set; }
 
        //public IFormFile fileImage { get; set; }
    }

    public class ProductUpdateItem
    {
        public DataUpdate data { get; set; }
    }
}
