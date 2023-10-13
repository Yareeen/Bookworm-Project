using Bookworm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    //Book modelini verdik. İnterfacei implement ettik.
    {
    }
}
