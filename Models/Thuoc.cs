using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPharmacy.Models
{
    public class Thuoc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenThuoc { get; set; }

        public string MoTa { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Gia { get; set; }

        public string? HinhAnhUrl { get; set; }

        [Required]
        public int LoaiThuocId { get; set; }

        [ForeignKey("LoaiThuocId")]
        public LoaiThuoc? LoaiThuoc { get; set; }
    }
}
