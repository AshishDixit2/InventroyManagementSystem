using InventoryManagement.Domain;
using InventoryManagement.Models;

namespace InventoryManagement.Interfaces
{
    public interface IProduct
    {
        public Guid AddProduct(PostProduct product);
        public void UpdateProduct(Guid id, PostProduct product);
        public void DeleteProduct(Guid id);
        public ViewProduct GetProductById(Guid id);
        public ICollection<ViewProduct> GetAllProduct();
    }
}