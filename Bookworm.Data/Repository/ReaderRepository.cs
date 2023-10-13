using Bookworm.Data.Repository.IRepository;
using Bookworm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository
{
    public class ReaderRepository : Repository<Reader>, IReaderRepository
    {
        private ApplicationDbContext _context;

        //constructor
        public ReaderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
