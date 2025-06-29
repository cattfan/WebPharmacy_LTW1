using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPharmacy.Data;
using WebPharmacy.Models;

namespace WebPharmacy.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class LoaiThuocAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoaiThuocAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiThuocAdmin
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiThuocs.ToListAsync());
        }

        // GET: Admin/LoaiThuocAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenLoai")] LoaiThuoc loaiThuoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiThuoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiThuoc);
        }

        // GET: Admin/LoaiThuocAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiThuoc = await _context.LoaiThuocs.FindAsync(id);
            if (loaiThuoc == null)
            {
                return NotFound();
            }
            return View(loaiThuoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLoai")] LoaiThuoc loaiThuoc)
        {
            if (id != loaiThuoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiThuoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.LoaiThuocs.Any(e => e.Id == loaiThuoc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(loaiThuoc);
        }

        // GET: Admin/LoaiThuocAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiThuoc = await _context.LoaiThuocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiThuoc == null)
            {
                return NotFound();
            }

            return View(loaiThuoc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiThuoc = await _context.LoaiThuocs.FindAsync(id);
            if (loaiThuoc != null)
            {
                _context.LoaiThuocs.Remove(loaiThuoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
