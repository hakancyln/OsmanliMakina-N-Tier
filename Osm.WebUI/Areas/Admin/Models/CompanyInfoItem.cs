namespace Osm.WebUI.Areas.Admin.Models
{
    public class CompanyInfoItem
    {
        public int ID { get; set; }
        public string About { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Adress { get; set; }
    }

    public class CompanyInfoRoot
    {
        public CompanyInfoItem data { get; set; }
    }
    //public class Data1
    //{
    //    public int ID { get; set; }
    //    public string About { get; set; }
    //    public string Tel { get; set; }
    //    public string Fax { get; set; }
    //    public string Mail1 { get; set; }
    //    public string Mail2 { get; set; }
    //    public string Adress { get; set; }
    //}

    //public class Root1
    //{
    //    public Data data { get; set; }
    //}
}
