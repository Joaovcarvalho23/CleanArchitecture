using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Shared.Behavior
{
    public sealed class ValidationBehavior<TRequest, TResponse> : 
                    IPipelineBehavior<TRequest, TResponse> 
                    where TRequest: IRequest<TResponse> //Essa classe implementa a interface IPipelineBehavior
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) //vai ser usado para validar os requests ANTES dele ser tratado pelo manipulador correspondente
        {
            _validators = validators;//aqui estamos injetando uma coleção de validadores validators, que é um IEnumerable de IValidator de T, e estamos armazenando na variável _validators.
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)//esse método é chamado quando uma solicitação/request for processada pelo MediatR, e ele vai implementar a lógica de validação do request. 
        {
            if (_validators.Any())//verifica se existem validadores na lista de _validators. Se não houver nenhum validador, o request é passado para o próximo comportamento (next())
                return await next();

            var context = new ValidationContext<TRequest>(request);//se houver validadores, é criado um ValidationContext que vai ser validado. Em seguida, a validação é executada dentro da condição abaixo:

            if (_validators.Any())//aqui vamos usar todos os validadores da lista.  
            {
                context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));//definimos, de forma assíncrona, a utilização do Task.WhenAll para cada validator; e estamos fazendo a validação. E os resultados vão ser coletados e armazenados em validationResults. 

                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();//havendo falhas de validação, elas são extraídas dos resultados, dando um SelectMany e armazenadas na variável failures.

                if (failures.Count != 0) //se houver falhas, se o contador de falhas for diferente de 0, lançamos uma exceção e exibimos as validações com base no que foi definido lá no CreateUserValidator.
                    throw new FluentValidation.ValidationException(failures);
            }
            return await next();
        }

    }

    //dessa forma, fazemos as validações de forma consistente no CQRS.
}
