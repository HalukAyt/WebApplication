using AspNetCore.Identity.MongoDbCore.Models;

using Microsoft.AspNetCore.Identity;
using WebApp.Business.Abstract;
using WebApp.Core.Models;
using WebApp.DataAccess.Abstract;
using WebApp.Entities.Concrete;
using WebApp.Models.ViewModels.Personels;

namespace WebApp.Business.Concrete
{
    public class PersonelManager(IPersonelDataAccess personelDataAccess) : IPersonelService
    {
        private readonly IPersonelDataAccess _personelDataAccess = personelDataAccess;

        public GetManyResult<Personel> GetPersonelsByAge()
        {
            var personelList = _personelDataAccess.GetAll();
            return personelList;
        }

   
    }
}
