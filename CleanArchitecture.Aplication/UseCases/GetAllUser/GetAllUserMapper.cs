using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.GetAllUser
{
    public sealed class GetAllUserMapper : Profile
    {
        public GetAllUserMapper() 
        {
            CreateMap<User, GetAllUserResponse>();
        }
    }
}
// Aqui temos o mapeamento do AutoMapper, que está mapenando o User no GetAllUserResponse