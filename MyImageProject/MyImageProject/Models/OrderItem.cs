using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey("Photographs")]
        public int PhotoId { get; set; }
        [Required]
        [ForeignKey("PrintSizes")]
        public int SizeId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Order Orders { get; set; }
        public Photograph Photographs { get; set; }
        public PrintSize PrintSizes { get; set; }
    }
}
