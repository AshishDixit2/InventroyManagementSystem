using InventoryManagement.Domain;
using System.Runtime.InteropServices;

namespace InventoryManagement.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);


        void DeleteRange(IEnumerable<TEntity> entities);

        TEntity Get(Guid id);
        public ICollection<TEntity> GetAll(ICollection<Guid>? ids);
    }
}


/*
 namespace InventoryManagement.Reposits
{
    public interface IRepository<T> where T : class
    {
            T GetById(int id);

            IEnumerable<T> GetAll();

            void Add(T entity);

            void Update(T entity);

            void Delete(T entity);

        }
}
*/
