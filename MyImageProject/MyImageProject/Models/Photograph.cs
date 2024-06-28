using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
    public class Photograph
    {
        [Key]
        public int PhotoId { get; set; }
        [Required]
        public string PhotoPath { get; set; }
        public DateTime UploadDate { get; set; }
        [Required]
        [ForeignKey("Users")]
        public string UserId { get; set; }
        public AppUsers Users { get; set; }
    }
}
