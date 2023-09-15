using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository // vai implementar a interface IUserRepository e vai estender a classe genérica BaseRepository onde o T é a entidade User. Isso significa que a classe UserRepository possui todos os métodos definidos em BaseRepository  
    {
        //Construtor
        public UserRepository(AppDbContext context) : base(context)
        { }//nesse construtor estamos recebendo uma instância de AppDbContext como parâmetro. Em seguida, chamamos o construtor da classe base (que é o BaseRepository<User>)  passando o contexto recebido. Isso garante que o contexto do banco de dados esteja disponível para a classe UserRepository, para que ela possa realizar as operações de banco de dados

        public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }//aceita 2 parâmetros: O email do usuário que eu desejo procurar, e o CancellationToken para cancelar uma operação caso seja necessário.
         //nesse método, ele tá usando o contexto do banco de dados para fazer uma consulta na tabela User usando como o método FirstOrDefaultAsync procurando pelo email. Ele vai retornar uma tarefa assíncrona que encapsula o objeto correspondente ao usuário que foi encontrado com o email passado como parâmetro.  
    }
}
