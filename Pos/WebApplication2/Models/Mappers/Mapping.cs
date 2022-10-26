using AutoMapper;
using Model.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models.DTOs;

namespace WebApplication2.Models.Mappers
{
    public class Mapping : Profile
    {
        // Startup nereden soracaktı.
        // burda yol gösteriyorum.

        public Mapping()
        {
            CreateMap<CreateUserDTO, AppUser>().ReverseMap(); // reverseMap : mapleme işlemini iki yönlü çalıştır.
          



        }
    }
}
