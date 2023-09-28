using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.UseCases.DeleteUser
{
    public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle (DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.Id, cancellationToken);//obtemos o usuário pelo Id

            if (user == null)
                return default;//verificamos se o usuário é nulo 

            _userRepository.Delete(user); //usamos o método .Delete() do repositório para excluir 
            await _unitOfWork.Commit(cancellationToken);// fazemos a persistência

            return _mapper.Map<DeleteUserResponse>(user);// e por fim, fazemos o mapeamento
        }
    }
}
