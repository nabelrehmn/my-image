using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using MyImageProject.Models;

namespace MyImageProject.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ApplicationDbContext Db_Context;
        public ShippingController( ApplicationDbContext _ShippingInfo)
        {
            this.Db_Context = _ShippingInfo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Details = await Db_Context.ShippingInfo.ToListAsync();
            return View(Details);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddShippment(ShippingInfo shipping)
        {
            await Db_Context.AddAsync(shipping);
            await Db_Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Record = await Db_Context.ShippingInfo.FindAsync(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            return View(Record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, ShippingInfo shipping)
        {
            if (Id != shipping.ShippingId)
            {
                return RedirectToAction("Index");
            }

            Db_Context.ShippingInfo.Update(shipping);
            await Db_Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var Record = Db_Context.ShippingInfo.Find(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            Db_Context.ShippingInfo.Remove(Record);
            Db_Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
