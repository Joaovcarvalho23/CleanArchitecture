using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IBaseRepository <Tipo> where Tipo : BaseEntity
    {
        void Create(Tipo entity);
        void Update(Tipo entity);
        void Delete(Tipo entity);
        Task<Tipo> Get(Guid id, CancellationToken cancellationToken);
        Task<List<Tipo>> GetAll(CancellationToken cancellationToken);
    }
}
