using System.ComponentModel.DataAnnotations;
namespace InventoryManagement.Domain
{
    public class Product
    {        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public ProductCategory Category { get; set; }
    }
}
