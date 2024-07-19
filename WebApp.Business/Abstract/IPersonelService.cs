using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;
using WebApp.Entities.Concrete;
using WebApp.Models.ViewModels.Personels;

namespace WebApp.Business.Abstract
{
    public interface IPersonelService
    {
        GetManyResult<Personel> GetPersonelsByAge();
    }
}
