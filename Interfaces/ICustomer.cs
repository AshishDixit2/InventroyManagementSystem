using InventoryManagement.Models;

namespace InventoryManagement.Interfaces
{
    public interface ICustomer
    {
        public Guid AddCustomer(PostCustomer customer);
        public void UpdateCustomer(Guid id, PostCustomer customer);
        public void DeleteCustomer(Guid id);
        public ViewCustomer GetOrdersByCustomers(Guid id);
    }
}
