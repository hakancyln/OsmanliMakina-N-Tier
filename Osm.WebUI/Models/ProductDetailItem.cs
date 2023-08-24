using Osm.ModelLayer.Entities;

namespace Osm.WebUI.Models
{
    public class ProductDetailItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public int CategoryID { get; set; }
        public string? Image { get; set; }
        public List<ProductImage> Images { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<object> product { get; set; }
    }

    public class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string descriptionEn { get; set; }
        public string categoryName { get; set; }
        public int categoryID { get; set; }
        public string? image { get; set; }
        public List<Image>? images { get; set; }
    }

    public class Image
    {
        public int id { get; set; }
        public int productID { get; set; }
        public string image { get; set; }
        public Product product { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string descriptionEn { get; set; }
        public int categoryID { get; set; }
        public string? image { get; set; }
        public Category category { get; set; }
        public List<Image> images { get; set; }
    }

    public class Root
    {
        public Data data { get; set; }
        //public object errorMessage { get; set; }
    }




}
