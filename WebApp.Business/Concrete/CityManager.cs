using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Business.Abstract;
using WebApp.Core.Models;
using WebApp.DataAccess.Abstract;
using WebApp.Entities.Concrete;

namespace WebApp.Business.Concrete
{
    public class CityManager(ICityDataAccess cityDataAccess) : ICityService
    {
        private readonly ICityDataAccess _cityDataAccess = cityDataAccess;

        public async Task<GetManyResult<City>> GetAllCitiesAsync()
        {
            return await _cityDataAccess.GetAllAsync();
        }
    }
}
