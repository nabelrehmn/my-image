using Microsoft.AspNetCore.Identity;

namespace MyImageProject.Models
{
    public class AppUsers : IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string ShippingAddess { get; set; } = "";
        public string BillingAddress { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
