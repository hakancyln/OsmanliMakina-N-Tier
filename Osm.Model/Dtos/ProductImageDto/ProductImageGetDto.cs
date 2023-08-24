using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.ProductImageDto
{
    public class ProductImageGetDto:IDto
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int ProductID { get; set; }

    }
}
