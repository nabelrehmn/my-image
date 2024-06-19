using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using MyImageProject.Models;

namespace MyImageProject.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ApplicationDbContext _ShippingContext;
        public ShippingController( ApplicationDbContext ShippingInfo)
        {
            this._ShippingContext = ShippingInfo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ShippingInfos = await _ShippingContext.ShippingInfo.ToListAsync();
            return View(ShippingInfos);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddShippment(ShippingInfo shipping)
        {
            await _ShippingContext.AddAsync(shipping);
            await _ShippingContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Record = await _ShippingContext.ShippingInfo.FindAsync(Id);
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

            _ShippingContext.ShippingInfo.Update(shipping);
            await _ShippingContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var Record = _ShippingContext.ShippingInfo.Find(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            _ShippingContext.ShippingInfo.Remove(Record);
            _ShippingContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
