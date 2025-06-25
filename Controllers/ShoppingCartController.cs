using Microsoft.AspNetCore.Mvc;
using WebPharmacy.Models;
using WebPharmacy.Repositories.Interfaces;
using WebPharmacy.Services;
using WebPharmacy.ViewModels;

namespace WebPharmacy.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IThuocRepository _thuocRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IThuocRepository thuocRepository, ShoppingCart shoppingCart)
        {
            _thuocRepository = thuocRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(sCVM);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var selectedThuoc = await _thuocRepository.GetByIdAsync(id);
            if (selectedThuoc != null)
            {
                _shoppingCart.AddToCart(selectedThuoc, 1);
            }
            return RedirectToAction("Index");
        }

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var selectedThuoc = await _thuocRepository.GetByIdAsync(id);
            if (selectedThuoc != null)
            {
                _shoppingCart.RemoveFromCart(selectedThuoc);
            }
            return RedirectToAction("Index");
        }
    }
}
