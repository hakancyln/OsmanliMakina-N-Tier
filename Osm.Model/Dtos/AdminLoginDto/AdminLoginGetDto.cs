﻿using Osm.CommonTypesLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osm.ModelLayer.Dtos.AdminLoginDto
{
    public class AdminLoginGetDto:IDto
    {
        public  int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}