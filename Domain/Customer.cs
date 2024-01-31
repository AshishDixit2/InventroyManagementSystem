using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using InventoryManagement.Domain;



    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Order> Orders { get; set; }
    }

