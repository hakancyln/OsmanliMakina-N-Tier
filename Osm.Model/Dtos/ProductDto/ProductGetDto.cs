using Osm.CommonTypesLayer.Model;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.ProductDto
{
    public class ProductGetDto:IDto
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryID { get; set; }

        public string? Image { get; set; }
        public List<ProductImage> Images { get; set; }
    }

}
