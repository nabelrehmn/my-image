using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using MyImageProject.Models;

namespace MyImageProject.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext Db_Context;
        public OrderController(ApplicationDbContext _Orders)
        {
            Db_Context = _Orders;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Details = await Db_Context.Orders.ToListAsync();
            return View(Details);
        }

        public IActionResult Delete(int Id)
        {
            var Record = Db_Context.Orders.Find(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            Db_Context.Orders.Remove(Record);
            Db_Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
