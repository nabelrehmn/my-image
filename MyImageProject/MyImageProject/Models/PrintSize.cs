using System.ComponentModel.DataAnnotations;

namespace MyImageProject.Models
{
    public class PrintSize
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        public string SizeName { get; set; }
        public string? SizeDescription { get; set; }
        [Required]
        public string Price { get; set; }
    }
}
