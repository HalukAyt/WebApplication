using WebApp.Entities.Concrete;
using WebApp.Core.Settings;
using WebApp.DataAccess.Abstract;
using WebApp.DataAccess.Context;
using WebApp.DataAccess.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApp.DataAccess.Concrete
{
    public class PersonelDataAccess : MongoRepositoryBase<Personel>, IPersonelDataAccess
    {
        private readonly MongoDbContext _context;
#pragma warning disable IDE0052 // Remove unread private members
        private readonly IMongoCollection<Personel> _collection;
#pragma warning restore IDE0052 // Remove unread private members
        public PersonelDataAccess(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Personel>();
        }
       
    }
}
