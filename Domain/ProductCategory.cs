using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis;

namespace InventoryManagement.Domain
{
    public class ProductCategory : BaseDomain
    {
        public string Name { get; set; }
       
    }
}
