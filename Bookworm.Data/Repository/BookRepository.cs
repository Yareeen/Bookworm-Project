using Bookworm.Data.Repository.IRepository;
using Bookworm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
