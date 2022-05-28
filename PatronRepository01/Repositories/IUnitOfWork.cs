using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepository01.Repositories
{
    interface IUnitOfWork
    {
        IRepository<autores> AutorRepository { get; }

        void Commit();

        void RejectChanges();

        void Dispose();
    }
}
