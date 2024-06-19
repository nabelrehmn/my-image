using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string TotalPrice { get; set; }
        [Required]
        public bool PaymentStatus { get; set; }
        [Required]
        public bool ShippingStatus { get; set; }
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public AppUsers Users { get; set; }
    }
}
