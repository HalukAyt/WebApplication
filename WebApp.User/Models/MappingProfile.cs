using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Entities.Concrete;
using WebApp.Models.ViewModels.Personels;

namespace WebApp.User.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personel, PersonelProfileInfo>().ReverseMap();
        }
    }
}
