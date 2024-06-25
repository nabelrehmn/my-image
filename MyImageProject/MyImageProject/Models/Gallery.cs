using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyImageProject.Models
{
	public class Gallery
	{
		[Key]
		public int GalleryId { get; set; }
		[Required]
		public string GalleryName { get; set; }
		[Required]
		public string Image { get; set; }
		[Required]
		public string TotalPrice { get; set; }
	}
}
