using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public string Paymenttype { get; set; }
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentAmount { get; set; }
        [Required]
        public bool PaymentStatus { get; set; }
        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public Order Orders { get; set; }
    }
}
