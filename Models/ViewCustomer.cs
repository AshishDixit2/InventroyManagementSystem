using InventoryManagement.Domain;
using InventoryManagement.Interfaces;
using InventoryManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class ViewCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<ViewOrder>? Orders { get; set; }

        public ViewCustomer(Customer customer, ICollection<ViewOrder>? orders)
        {
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumber = customer.Phone;
            Orders = orders;
        }
    }
}