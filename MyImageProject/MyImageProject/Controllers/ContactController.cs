using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;

namespace MyImageProject.Controllers
{
	public class ContactController : Controller
	{
        private readonly ApplicationDbContext Db_Context;
        public ContactController(ApplicationDbContext _Contact)
        {
            this.Db_Context = _Contact;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Details = await Db_Context.Contact.ToListAsync();
            return View(Details);
        }

        public IActionResult Delete(int Id)
        {
            var Record = Db_Context.Contact.Find(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            Db_Context.Contact.Remove(Record);
            Db_Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
