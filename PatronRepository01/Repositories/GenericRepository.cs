using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepository01.Repositories
{
    class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ModelAutores _dbContext; // CAMBIAR MODELAUTORES

        private System.Data.Entity.DbSet<T> _dbSet => _dbContext.Set<T>();

        public IQueryable<T> Entities => _dbSet;

        public GenericRepository(ModelAutores dbContext) // CAMBIAR MODELAUTORES
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
