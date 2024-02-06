using InventoryManagement.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace InventoryManagement.Interfaces
{
    public interface IOrder
    {
        public Guid AddOrder(PostOrder order);
        public void DeleteOrder(Guid id);
    }
}
