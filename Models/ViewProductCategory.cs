using InventoryManagement.Domain;

namespace InventoryManagement.Models
{
    public class ViewProductCategory
    {
        public string Name { get; set; }

        public ViewProductCategory() { }
        public ViewProductCategory(ProductCategory category)
        {
            Name = category.Name;
        }
    }
}