using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.GetAllUser
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;
}

//Esse método vai retornar uma lista de GetAllUserResponse
