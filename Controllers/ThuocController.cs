using Microsoft.AspNetCore.Mvc;
using WebPharmacy.Repositories.Interfaces;

namespace WebPharmacy.Controllers
{
    public class ThuocController : Controller
    {
        private readonly IThuocRepository _thuocRepository;

        public ThuocController(IThuocRepository thuocRepository)
        {
            _thuocRepository = thuocRepository;
        }

        // Action này sẽ là trang Shop chính
        public async Task<IActionResult> Index()
        {
            var thuocs = await _thuocRepository.GetAllAsync();
            return View(thuocs);
        }

        // Action này để xem chi tiết 1 sản phẩm
        public async Task<IActionResult> Details(int id)
        {
            var thuoc = await _thuocRepository.GetByIdAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }
            return View(thuoc);
        }
    }
}
