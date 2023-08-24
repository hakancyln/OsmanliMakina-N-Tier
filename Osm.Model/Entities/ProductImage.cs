using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Entities
{
    public class ProductImage : IEntity
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Image { get; set; }
        public Product? Product { get; set; }

    }
}
