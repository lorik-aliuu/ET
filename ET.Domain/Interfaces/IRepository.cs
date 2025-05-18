using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ET.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id, CancellationToken ct = default);

        Task AddAsync(T entity, CancellationToken ct = default);

        void Update(T entity);

        void Delete(T entity);

    }
}
