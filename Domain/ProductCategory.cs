using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;

namespace InventoryManagement.Domain
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
       
    }
}
