using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable //hızlandırmaya yarar
    {
        IBookRepository Book { get; }
        ICategoryRepository Category { get; }
        ICommantBookRepository CommantBook { get; }
        IReaderRepository Reader { get; }

        void Save();
    }
}
