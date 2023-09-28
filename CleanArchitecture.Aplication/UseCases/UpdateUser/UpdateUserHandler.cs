using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork; //fazendo a persistência dos dados
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle (UpdateUserRequest command, CancellationToken cancellationToken) //nós mandamos um UpdateUserRequest (command) que vai conter o Id do usuário.  
        {
            var user = await _userRepository.Get(command.Id, cancellationToken); //vamos obter o usuário através do Id 

            if (user == null)
                return default; //verificamos se o usuário não é null

            user.Name = command.Name; //vamos obter o nome e o email do command que vem do request
            user.Email = command.Email;

            _userRepository.Update(user);//ataulizamos o usuário 

            await _unitOfWork.Commit(cancellationToken);//vamos persistir usando a _unitOfWork

            return _mapper.Map<UpdateUserResponse>(user);//e para finalizar, fazemos o mapeamento do automapper, usando automapper aqui
        }
    }
}
