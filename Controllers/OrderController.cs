using Microsoft.AspNetCore.Mvc;
using WebPharmacy.Models;
using WebPharmacy.Repositories.Interfaces;
using WebPharmacy.Services;

namespace WebPharmacy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            _shoppingCart.GetShoppingCartItems();
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Giỏ hàng của bạn đang trống, hãy thêm sản phẩm trước khi thanh toán.");
                TempData["CartIsEmpty"] = "Giỏ hàng của bạn đang trống, hãy thêm sản phẩm trước khi thanh toán.";
                return RedirectToAction("Index", "ShoppingCart");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Giỏ hàng của bạn đang trống, hãy thêm sản phẩm trước khi thanh toán.");
            }

            if (ModelState.IsValid)
            {
                order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return View("CheckoutComplete", order);
            }
            return View(order);
        }
    }
}
