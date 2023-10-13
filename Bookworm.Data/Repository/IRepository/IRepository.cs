using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
        /*generic yaptık
        hangi model gelirse onu temsil eder
        Veritabanı sorguları için bir interface oluşturduk.
         */
    {
        void Add(T entity);//crudun creatini gerçekleştirir.
        T GetFirstOrDefault(Expression<Func<T, bool>> filter,
            string? includeProperties = null);

        //liste halinde gelebilir.
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
