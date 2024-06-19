using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
    public class ShippingInfo
    {
        [Key]
        public int ShippingId { get; set; }
        [Required]
        public string ShippingAddress { get; set; }
        [Required]
        public string ShippingMethod { get; set; }
        [Required]
        public string TracingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public Order Orders { get; set; }
    }
}
