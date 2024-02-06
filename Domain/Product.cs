

namespace InventoryManagement.Domain
{
    public class Product : BaseDomain
    {
        public Guid CategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public virtual ICollection<OrderProduct>? Orders { get; }
    }
}
