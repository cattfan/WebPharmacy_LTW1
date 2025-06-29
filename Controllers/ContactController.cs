using Microsoft.AspNetCore.Mvc;
using WebPharmacy.Data;
using WebPharmacy.Models;
using System;
using System.Threading.Tasks;

namespace WebPharmacy.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                lienHe.NgayGui = DateTime.Now;
                _context.LienHes.Add(lienHe);
                await _context.SaveChangesAsync();
                return RedirectToAction("ThankYou");
            }
            return View(lienHe);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
