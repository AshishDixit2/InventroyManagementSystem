using InventoryManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Reposits

    {

        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly InventoryDbContext _context;
            private readonly DbSet<T> _entities;

            public Repository(InventoryDbContext context)
            {
                _context = context;
                _entities = context.Set<T>();
            }

            public T GetById(int id)
            {
                return _entities.Find(id);
            }

            public IEnumerable<T> GetAll()
            {
                return _entities.ToList();
            }

            public void Add(T entity)
            {
                _entities.Add(entity);
                _context.SaveChanges();
            }

            public void Update(T entity)
            {
                _entities.Update(entity);
                _context.SaveChanges();
            }

            public void Delete(T entity)
            {
                _entities.Remove(entity);
                _context.SaveChanges();
            }
        }
}

