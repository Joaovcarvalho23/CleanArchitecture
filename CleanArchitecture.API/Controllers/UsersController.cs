using CleanArchitecture.Aplication.UseCases.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;//atributo que vai ser usada para injetar uma instância do Mediator no construtor

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //método httpPost, é o nosso endpoint 

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest request, CancellationToken cancellationToken)//estamos criando o método Create, que será chamado quando houver um request HttpPost para a rota "api/[controller]". Ele vai receber um objeto do tipo CreateUserRequest (dados para criar um novo usuário) e um CancellationToken para, se quiser, cancelar o request.
        {
            //fazendo uma validação caso tenha erro
            //Método do MediatR: behavior -> Pipeline behavior: usado para adicionar lógica de processamento antes e depois de um manipulador de solicitação e permite adicionar comportamentos globais a todas as solicitações ou a um subconjunto específico delas.

            //Método convencional:
            //var validator = new CreateUserValidator();
            //var validationResult = await validator.ValidateAsync(request);

            //if (!validationResult.IsValid)
            //    return BadRequest(validationResult.Errors);

            var response = await _mediator.Send(request, cancellationToken);//Estamos usando o método Send do Mediator para enviar o objeto request (do tipo CreateUserRequest) que vai fazer roteamento para o nosso comando, que vai ser o CreateUserHandler; e o await vai aguardar a execução do manipulador que vai retornar uma resposta, que vai ser do tipo CreateUserResponse.
            return Ok(response);//retornamos para o usuário um http 200 contendo a resposta obtida do manipulador que vai conter os detalhes do usuário que foi criado.
        }
        
    }
}
