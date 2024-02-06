using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using InventoryManagement.Domain;



    public class Customer : BaseDomain
    {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
}

