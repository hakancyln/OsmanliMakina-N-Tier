using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.MessageDto
{
    public class MessagePostDto:IDto
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Subject { get; set; }
        public string Messages { get; set; }
    }
}
