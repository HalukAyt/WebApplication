using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;
using WebApp.Entities.Concrete;

namespace WebApp.Business.Abstract
{
    public interface ICityService
    {
        Task<GetManyResult<City>> GetAllCitiesAsync();
    }
}
