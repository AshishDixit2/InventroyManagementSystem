using System.ComponentModel.DataAnnotations;
namespace InventoryManagement.Domain;


    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public Product Product { get; set; }
    }

