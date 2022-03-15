using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeFoodIOApp.Data.Models;

namespace TakeFoodIOApp.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
       readonly Context c = new Context();

        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }

        public void TDelete(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }

        public void TUpdate(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }

        public T TGet(int id)
        {
           return c.Set<T>().Find(id);
        }

        // Include method added for relational database
        public List<T> TList(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }
    }
}
