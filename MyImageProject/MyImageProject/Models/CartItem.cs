using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public AppUsers Users { get; set; }

        [Required]
        [ForeignKey("Photographs")]
        public int PhotoId { get; set; }
        public Photograph Photographs { get; set; }

        [Required]
        [ForeignKey("PrintSizes")]
        public int SizeId { get; set; }
        public PrintSize PrintSizes { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
