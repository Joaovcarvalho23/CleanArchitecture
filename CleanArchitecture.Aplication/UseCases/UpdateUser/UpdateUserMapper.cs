using AutoMapper;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.UpdateUser
{
    public sealed class UpdateUserMapper : Profile
    {
        public UpdateUserMapper()
        {
            CreateMap<UpdateUserRequest, User>();//mapeamento de UpdateUserRequest para User
            CreateMap<User, UpdateUserResponse>();//mapeamento de User para UpdateUserResponse
        }
    }
}
