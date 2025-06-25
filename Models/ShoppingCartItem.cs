using System.ComponentModel.DataAnnotations;

namespace WebPharmacy.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Thuoc Thuoc { get; set; }
        public int SoLuong { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
