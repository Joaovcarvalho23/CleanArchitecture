using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork //A classe implementa a interface IUnitOfWork
                                          //A principal responsabilidade dessa classe é gerenciar a transação e o commit de operações no contexto de banco de dados 
    {
        private readonly AppDbContext _context; //vai estar representando o contexto do banco de dados do IUnitOfWork

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }//nesse método ele tá aceitando um parametro opcional, o cancellationToken. E dentro ele chama um método que vai salvar todas as alterações pendentes no banco de dados
    }
}
