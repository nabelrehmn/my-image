using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyImageProject.Models
{
    public class UploadViewModel
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public int SelectedSizeId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public List<SelectListItem> Sizes { get; set; }
    }
}
