using WebPharmacy.Models;

namespace WebPharmacy.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
