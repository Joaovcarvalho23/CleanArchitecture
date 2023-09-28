using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.UpdateUser
{
    public sealed record UpdateUserRequest(Guid Id, string Email, string Name) : IRequest<UpdateUserResponse>;
}
//passamos o Id do usuário e os dados que eu quero alterar 