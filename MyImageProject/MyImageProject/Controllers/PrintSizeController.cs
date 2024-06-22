using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using MyImageProject.Models;

namespace MyImageProject.Controllers
{
    public class PrintSizeController : Controller
    {
        private readonly ApplicationDbContext Db_Context;
        public PrintSizeController(ApplicationDbContext _PrintSize)
        {
            this.Db_Context = _PrintSize;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Details = await Db_Context.PrintSizes.ToListAsync();
            return View(Details);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSizes(PrintSize sizes)
        {
            await Db_Context.AddAsync(sizes);
            await Db_Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var Record = await Db_Context.PrintSizes.FindAsync(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            return View(Record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, PrintSize sizes)
        {
            if (Id != sizes.SizeId)
            {
                return RedirectToAction("Index");
            }

            Db_Context.PrintSizes.Update(sizes);
            await Db_Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var Record = Db_Context.PrintSizes.Find(Id);
            if (Record == null)
            {
                return RedirectToAction("Index");
            }
            Db_Context.PrintSizes.Remove(Record);
            Db_Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

