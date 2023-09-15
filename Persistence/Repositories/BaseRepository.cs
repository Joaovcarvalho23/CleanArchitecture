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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        
        protected readonly AppDbContext Context; //definindo uma variável protegida que vai ser acessível às classes derivadas que vai armazenar uma instância de AppDbContext
        //Construtor v
        public BaseRepository(AppDbContext context)
        {
            Context = context;
        } //aqui estamos injetando uma instância de AppDbContext, pra poder usar essa instância e realizar as operações do repositório 
        

        //Implementando os métodos CRUD
        public void Create(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            Context.Add(entity);

        }//Cria uma nova entidade. Vai definir a data de criação e vai adicionar essa entidade ao contexto

        public void Delete(T entity)
        {
            entity.DateDeleted = DateTimeOffset.UtcNow;
            Context.Remove(entity);

        }//vai excluir uma entidade, definindo a data de exclusão. E depois vai remover a entidade do contexto

        public async Task<T> Get(Guid id, CancellationToken cancellationToken)
        {
#pragma warning disable CS8603 // Possível retorno de referência nula.
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);//Busca uma entidade do tipo T pelo seu id, e usa o método FirstOrDefaultAsync para consultar o contexto do banco de dados e retornar a primeira entidade que corresponda ao id passado como parâmetro 
#pragma warning restore CS8603 // Possível retorno de referência nula.
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }//vai buscar todas as entidades do tipo T que, nesse caso, T vai representar nossa entidade User, e vai retornar uma lista usando o método ToListAsync

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            Context.Update(entity);

        } //vai atualizar uma entidade e vai definir a data de atualização e vai marcar essa entidade como atualizada no contexto
    }
}
