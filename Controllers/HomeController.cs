using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebPharmacy.Models;
using WebPharmacy.Repositories.Interfaces;

namespace WebPharmacy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IThuocRepository _thuocRepository;

        public HomeController(IThuocRepository thuocRepository)
        {
            _thuocRepository = thuocRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allThuoc = await _thuocRepository.GetAllAsync();
            return View(allThuoc);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
