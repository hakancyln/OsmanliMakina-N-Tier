﻿using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Entities
{
    public class Message : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Subject { get; set; }
        public string Messages { get; set; }
    }
}
