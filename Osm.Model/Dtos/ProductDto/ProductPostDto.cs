using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.ProductDto
{
    public class ProductPostDto:IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string CategoryID { get; set; }
        public string? Image { get; set; }
    }
}
