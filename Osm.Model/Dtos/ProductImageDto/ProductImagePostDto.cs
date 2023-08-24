using Osm.CommonTypesLayer.Model;
using Osm.ModelLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.ProductImageDto
{
    public class ProductImagePostDto:IDto
    {
        public int ProductID { get; set; }
        public string Image { get; set; }
    }
}
