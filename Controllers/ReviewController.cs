using Mailo.Data;
using Mailo.IRepo;
using Mailo.Models;
using Mailoo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Mailo.Controllers
{
    [Authorize(Roles = "Admin,Client")]
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewController(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        public IActionResult Create(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int productId, string content, int? rating, IFormFile? clientFile)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ID == productId);
            if (product == null)
            {
                TempData["Error"] = "المنتج غير موجود.";
                return RedirectToAction("Index", "Home");
            }

            User? user = await _unitOfWork.userRepo.GetUser(User.Identity?.Name);
            if (user == null) return RedirectToAction("Login", "Account");
          

            string? imageUrl = null;
            if (clientFile != null && clientFile.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(clientFile.FileName);
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);
                using (var stream = new FileStream(uploadPath, FileMode.Create))
                {
                    await clientFile.CopyToAsync(stream);
                }
                imageUrl = "/uploads/" + fileName;
            }

            var review = new Review
            {
                Content = content,
                Rating = rating ?? 0,
                ImageUrl = imageUrl,
                UserId = user.ID, // استخدم Id بدلاً من Username
                ProductId = productId,
                Date = DateTime.Now // تأكد من أن الخاصية موجودة
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            TempData["Success"] = "تمت إضافة التقييم بنجاح!";
            return RedirectToAction("Details", "Product", new { id = productId });
        }

        [HttpGet]
        public async Task<IActionResult> List(int productId)
        {
            var reviews = await _context.Reviews
                .Where(r => r.ProductId == productId)
                .OrderByDescending(r => r.Date)
                .ToListAsync();

            ViewBag.ProductId = productId;
            return View(reviews);
        }
    }
}
