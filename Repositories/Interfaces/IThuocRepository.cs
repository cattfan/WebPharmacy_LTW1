using WebPharmacy.Models;

namespace WebPharmacy.Repositories.Interfaces
{
    public interface IThuocRepository
    {
        Task<IEnumerable<Thuoc>> GetAllAsync();
        Task<Thuoc> GetByIdAsync(int id);
    }
}
