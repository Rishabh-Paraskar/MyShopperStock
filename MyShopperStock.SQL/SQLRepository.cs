using MyShopperStock.Core.Contracts;
using MyShopperStock.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MyShopperStock.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext dbcontext;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context) {
            this.dbcontext = context;
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> collection()
        {
            return dbSet;
        }

        public void commit()
        {
            dbcontext.SaveChanges();
        }

        public void delete(string id)
        {
            var v=dbSet.Find(id);
            if (dbcontext.Entry(v).State == EntityState.Detached) {
                dbSet.Attach(v);
            }

            dbSet.Remove(v);
        }

        public T find(string id)
        {
            return dbSet.Find(id);
        }

        public void insert(T t)
        {
            dbSet.Add(t);
        }

        public void update(T t)
        {
            dbSet.Attach(t);
            dbcontext.Entry(t).State=EntityState.Modified;
        }
    }
}
