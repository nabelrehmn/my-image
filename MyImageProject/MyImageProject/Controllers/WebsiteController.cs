using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyImageProject.Data;
using MyImageProject.Models;

namespace MyImageProject.Controllers
{
    public class WebsiteController : Controller
    {
        private readonly ApplicationDbContext Db_context;
        private readonly UserManager<AppUsers> UserManager;

        public WebsiteController(ApplicationDbContext _Contact, UserManager<AppUsers> _UserManager)
		{
			this.Db_context = _Contact;
			this.UserManager = _UserManager;
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
		}public IActionResult OrderConfirmation()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Contact(Contact contact)
		{
            await Db_context.AddAsync(contact);
            await Db_context.SaveChangesAsync();
			return Json(new { success = true });
		}

        // All Order Working //
        [HttpGet]
        public IActionResult Upload()
        {
            var sizes = Db_context.PrintSizes.Select(s => new SelectListItem
            {
                Value = s.SizeId.ToString(),
                Text = s.SizeName
            }).ToList();

            return View(sizes); // No model needed
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null && model.Image.Length > 0)
                {
                    var userId = UserManager.GetUserId(User);
                    var photoPath = Path.Combine("wwwroot/images", model.Image.FileName);

                    using (var stream = new FileStream(photoPath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(stream);
                    }

                    var photograph = new Photograph
                    {
                        PhotoPath = photoPath,
                        UploadDate = DateTime.Now,
                        UserId = userId
                    };

                    Db_context.Photographs.Add(photograph);
                    await Db_context.SaveChangesAsync();

                    var cartItem = new CartItem
                    {
                        UserId = userId,
                        PhotoId = photograph.PhotoId,
                        SizeId = model.SelectedSizeId,
                        Quantity = model.Quantity
                    };

                    Db_context.CartItems.Add(cartItem);
                    await Db_context.SaveChangesAsync();

                    return RedirectToAction("Cartlist");
                }
            }

            // If we got this far, something failed, redisplay form
            model.Sizes = Db_context.PrintSizes.Select(s => new SelectListItem
            {
                Value = s.SizeId.ToString(),
                Text = s.SizeName
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Cartlist()
        {
            var userId = UserManager.GetUserId(User);
            var cartItems = await Db_context.CartItems
                .Include(c => c.Photographs)
                .Include(c => c.PrintSizes)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            var viewModel = new CartViewModel
            {
                CartItems = cartItems
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CreditCard model)
        {
            var userId = UserManager.GetUserId(User);

            // Process payment (this is a placeholder, implement actual payment processing here)

            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = 100, // Calculate total price
                PaymentStatus = true, // Assume payment is successful
                ShippingStatus = false,
                UserId = userId
            };

            Db_context.Orders.Add(order);
            await Db_context.SaveChangesAsync();

            var cartItems = await Db_context.CartItems
                .Include(c => c.Photographs)
                .Include(c => c.PrintSizes)
                .Where(c => c.UserId == userId)
                .ToListAsync();

            foreach (var cartItem in cartItems)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    PhotoId = cartItem.PhotoId,
                    SizeId = cartItem.SizeId,
                    Quantity = cartItem.Quantity
                };

                Db_context.OrderItems.Add(orderItem);
            }

            await Db_context.SaveChangesAsync();

            // Clear the cart
            Db_context.CartItems.RemoveRange(cartItems);
            await Db_context.SaveChangesAsync();

            return RedirectToAction("OrderConfirmation");
        }
    }
}
