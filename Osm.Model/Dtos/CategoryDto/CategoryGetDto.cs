﻿using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.CategoryDto
{
    public class CategoryGetDto:IDto
    {
        public string Name { get; set; }
    }
}
