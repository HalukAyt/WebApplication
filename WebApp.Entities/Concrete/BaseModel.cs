﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Entities.Concrete
{
    public class BaseModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
