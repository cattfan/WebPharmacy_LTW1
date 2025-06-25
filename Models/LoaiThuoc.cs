using System.ComponentModel.DataAnnotations;

namespace WebPharmacy.Models
{
    public class LoaiThuoc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoai { get; set; }

        public List<Thuoc> Thuocs { get; set; }
    }
}
