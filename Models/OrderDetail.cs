using System.ComponentModel.DataAnnotations.Schema;

namespace WebPharmacy.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ThuocId { get; set; }
        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Gia { get; set; }

        public Thuoc Thuoc { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
