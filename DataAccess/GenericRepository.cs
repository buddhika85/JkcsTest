using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private DbSet<T> entities;        

        public GenericRepository(DbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public virtual T Get(object primaryKey)
        {
            return entities.Find(primaryKey);
        }
        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);            
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object primaryKey)
        {
            if (primaryKey == null)
            {
                throw new ArgumentNullException("entity");
            }
            T entityToDel = entities.Find(primaryKey);
            if (context.Entry(entityToDel).State == EntityState.Detached)
            {
                entities.Attach(entityToDel);
            }
            entities.Remove(entityToDel);
        }

        // Executing a stored procedure
        // Ref - http://stackoverflow.com/questions/27974080/using-generic-repository-and-stored-procedures
        // Ref - http://www.codedisqus.com/0HieUqXkUj/how-can-i-use-a-stored-procedure-repository-unit-of-work-patterns-in-entity-framework.html
        public virtual DbRawSqlQuery<TEntity> SQLQuery<TEntity>(string sql, params object[] parameters)
        {
            if (parameters != null)
            {
                return context.Database.SqlQuery<TEntity>(sql, parameters);
            }
            else
            {
                return context.Database.SqlQuery<TEntity>(sql);
            }
        }

    }
}
