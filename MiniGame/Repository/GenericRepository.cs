using MiniGame.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniGame.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ConnecDatabase _db { get; set; }
        protected DbSet<T> _table;
        public GenericRepository()
        {
            _db = new ConnecDatabase();
            _table = _db.Set<T>();
        }
        public GenericRepository(ConnecDatabase db)
        {
            _db = db;
            _table = _db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            return _table.ToList();
        }

        public T SelectById(object id)
        {
            try
            {
                return _table.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}