using Bookworm.Data.Repository.IRepository;
using Bookworm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository
{
    public class CommantBookRepository : Repository<CommantBook>, ICommantBookRepository
    {
        private ApplicationDbContext _context;
        public CommantBookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
