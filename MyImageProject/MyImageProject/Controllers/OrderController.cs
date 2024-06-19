using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;

namespace MyImageProject.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _OrderContext;
        public OrderController(ApplicationDbContext Orders)
        {
            _OrderContext = Orders ?? throw new ArgumentNullException(nameof(Orders));
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Orders = await _OrderContext.Orders.ToListAsync();
            return View();
        }
    }
}
