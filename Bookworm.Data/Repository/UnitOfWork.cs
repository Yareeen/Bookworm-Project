using Bookworm.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IBookRepository Book => new BookRepository(_context);
        //lamba kullandığımız için get ve returna gerek kalmaz.

        public ICategoryRepository Category => new CategoryRepository(_context);

        public ICommantBookRepository CommantBook => new CommantBookRepository(_context);

        public IReaderRepository Reader => new ReaderRepository(_context);

        public void Dispose() //ramde tutulmayı önler. İşlem yapıldıktan sonra
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
