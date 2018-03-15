using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(object primaryKey);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object primaryKey);
        DbRawSqlQuery<TEntity> SQLQuery<TEntity>(string sql, params object[] parameters);
    }
}
