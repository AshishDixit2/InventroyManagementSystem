﻿using InventoryManagement.Domain;
using System.Runtime.InteropServices;

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
