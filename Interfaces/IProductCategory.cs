using InventoryManagement.Models;

namespace InventoryManagement.Interfaces
{
    public interface IProductCategory
    {
        public ICollection<ViewProductCategory> GetAllCategory();
        public Guid AddCategory(PostProductCategory category);
        public ViewProductCategory GetCategory(Guid id);
    }
}


