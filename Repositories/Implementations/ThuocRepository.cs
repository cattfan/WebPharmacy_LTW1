using Microsoft.EntityFrameworkCore;
using WebPharmacy.Data;
using WebPharmacy.Models;
using WebPharmacy.Repositories.Interfaces;

namespace WebPharmacy.Repositories.Implementations
{
    public class ThuocRepository : IThuocRepository
    {
        private readonly ApplicationDbContext _context;

        public ThuocRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Thuoc>> GetAllAsync()
        {
            return await _context.Thuocs.Include(t => t.LoaiThuoc).ToListAsync();
        }

        public async Task<Thuoc> GetByIdAsync(int id)
        {
            return await _context.Thuocs.Include(t => t.LoaiThuoc).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
