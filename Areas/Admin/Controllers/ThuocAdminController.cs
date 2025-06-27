using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPharmacy.Data;
using WebPharmacy.Models;

namespace WebPharmacy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ThuocAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThuocAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Thuocs.Include(t => t.LoaiThuoc);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var thuoc = await _context.Thuocs
                .Include(t => t.LoaiThuoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thuoc == null) return NotFound();
            return View(thuoc);
        }

        public IActionResult Create()
        {
            ViewData["LoaiThuocId"] = new SelectList(_context.LoaiThuocs, "Id", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenThuoc,MoTa,Gia,HinhAnhUrl,LoaiThuocId")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiThuocId"] = new SelectList(_context.LoaiThuocs, "Id", "TenLoai", thuoc.LoaiThuocId);
            return View(thuoc);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc == null) return NotFound();
            ViewData["LoaiThuocId"] = new SelectList(_context.LoaiThuocs, "Id", "TenLoai", thuoc.LoaiThuocId);
            return View(thuoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenThuoc,MoTa,Gia,HinhAnhUrl,LoaiThuocId")] Thuoc thuoc)
        {
            if (id != thuoc.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Thuocs.Any(e => e.Id == thuoc.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiThuocId"] = new SelectList(_context.LoaiThuocs, "Id", "TenLoai", thuoc.LoaiThuocId);
            return View(thuoc);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var thuoc = await _context.Thuocs
                .Include(t => t.LoaiThuoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thuoc == null) return NotFound();
            return View(thuoc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc != null) _context.Thuocs.Remove(thuoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
