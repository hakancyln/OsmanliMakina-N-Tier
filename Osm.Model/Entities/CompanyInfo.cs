using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Entities
{
    public class CompanyInfo : IEntity
    {
        public int ID { get; set; }
        public string About { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Adress { get; set; }

    }
}
