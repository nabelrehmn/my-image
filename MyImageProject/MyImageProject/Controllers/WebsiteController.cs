using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using MyImageProject.Models;

namespace MyImageProject.Controllers
{
    public class WebsiteController : Controller
    {
		ApplicationDbContext Db_context;

		public WebsiteController(ApplicationDbContext _Contact)
		{
			this.Db_context = _Contact;
		}

		public async Task<IActionResult> Index()
        {
            var Gallery = await Db_context.Gallery.ToListAsync();
			return View(Gallery);
        }
        public IActionResult Gallery()
        {
			var Gallery = Db_context.Gallery.ToList();
			return View(Gallery);
		}
        public IActionResult Custom()
        {
            return View();
        }
		public IActionResult About()
        {
            return View();
        }
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult Cart()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Contact(Contact contact)
		{
			Contact Contact = new Contact
			{
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Subject = contact.Subject,
				Massage = contact.Massage
			};

            Db_context.Add(Contact);
            Db_context.SaveChanges();
			return RedirectToAction("Contact");
		}
	}
}
