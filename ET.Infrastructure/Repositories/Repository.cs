using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;
using ET.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ET.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ApplicationDbContext _context;
        protected readonly DbSet<T> _set;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public Task<T> GetByIdAsync(int id, CancellationToken ct = default) =>
            _set.FindAsync(new object[] { id }, ct).AsTask();


        public Task AddAsync(T entity, CancellationToken ct = default) =>
            _set.AddAsync(entity, ct).AsTask();

        public void Update(T entity) => _set.Update(entity);

        public void Delete(T entity)
        {
            entity.Delete();
            _set.Update(entity);
        }
    }
}

