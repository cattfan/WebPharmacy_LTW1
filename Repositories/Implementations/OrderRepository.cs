using WebPharmacy.Data;
using WebPharmacy.Models;
using WebPharmacy.Repositories.Interfaces;
using WebPharmacy.Services;

namespace WebPharmacy.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    SoLuong = item.SoLuong,
                    ThuocId = item.Thuoc.Id,
                    OrderId = order.OrderId,
                    Gia = item.Thuoc.Gia
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}
