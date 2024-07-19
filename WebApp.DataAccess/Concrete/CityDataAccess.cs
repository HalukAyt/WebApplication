using WebApp.Entities.Concrete;
using WebApp.Core.Settings;
using WebApp.DataAccess.Abstract;
using WebApp.DataAccess.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.DataAccess.Concrete
{
    public class CityDataAccess(IOptions<MongoSettings> settings) : MongoRepositoryBase<City>(settings), ICityDataAccess
    {
    }
}
