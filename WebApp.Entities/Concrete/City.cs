﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Entities.Concrete
{
    public class City : BaseModel
    {
        public string? Name { get; set; }
        public string? Plate { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public ICollection<County>? Counties { get; set; }
    }
}
