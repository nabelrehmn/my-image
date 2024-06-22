using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;

namespace MyImageProject.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext Db_Context;
        public PaymentController(ApplicationDbContext _Payment)
        {
            this.Db_Context = _Payment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Details = await Db_Context.Payments.ToListAsync();
            return View(Details);
        }

        public IActionResult Delete(int Id)
        {
            var Record = Db_Context.Payments.Find(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            Db_Context.Payments.Remove(Record);
            Db_Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
