using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.GetAllUser
{
    public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>> // Implementamos a interface IRequestHandler do MediatR, definindo o request e o response (obtendo uma lista de usuários)
    {
        private readonly IUserRepository _userRepository; //Definimos a utilização do meu repositório do AutoMapper
        private readonly IMapper _mapper;

        public GetAllUserHandler(IUserRepository userRepository, IMapper mapper) //Fazemos a injeção no construtor
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken) //Nesse método Handle da interface, usamos a instância do repositório e usamos o método .GetAll, passando o request e um token de cancelamento opcional
        {
            var users = await _userRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllUserResponse>>(users); //Temos o retorno dos objetos users. E aqui usamos o AutoMapper e retorno uma lista de GetAllUserResponse
        }
        
    }
}
