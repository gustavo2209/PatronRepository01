using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepository01.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ModelAutores _dbContext;

        #region Repositories

        IRepository<autores> IUnitOfWork.AutorRepository => new GenericRepository<autores>(_dbContext);

        #endregion

        public UnitOfWork(ModelAutores dbContext)
        {
            _dbContext = dbContext;
        }

        void IUnitOfWork.Commit()
        {
            _dbContext.SaveChanges();
        }

        void IUnitOfWork.Dispose()
        {
            _dbContext.Dispose();
        }

        void IUnitOfWork.RejectChanges()
        {
            foreach(var entry in _dbContext.ChangeTracker.Entries().Where(e => e.State != System.Data.Entity.EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case System.Data.Entity.EntityState.Added:
                        entry.State = System.Data.Entity.EntityState.Detached;
                        break;

                    case System.Data.Entity.EntityState.Modified:
                    case System.Data.Entity.EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }
}
