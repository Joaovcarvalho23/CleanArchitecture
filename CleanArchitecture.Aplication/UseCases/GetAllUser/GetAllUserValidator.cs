using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.GetAllUser
{
    public class GetAllUserValidator : AbstractValidator<GetAllUserResponse>
    {
        public GetAllUserValidator()
        {
            //sem validação. Apenas retorno o dado.
        }
    }
}
