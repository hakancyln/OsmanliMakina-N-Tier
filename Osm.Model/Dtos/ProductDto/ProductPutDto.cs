using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.ProductDto
{
    public class ProductPutDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public int CategoryID { get; set; }
        public string? Image { get; set; }

    }
}
