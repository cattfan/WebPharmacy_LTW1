using System.ComponentModel.DataAnnotations;

namespace WebPharmacy.Models
{
    public class LienHe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100)]
        [Display(Name = "Họ và Tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung tin nhắn")]
        [Display(Name = "Nội dung tin nhắn")]
        public string TinNhan { get; set; }

        public DateTime NgayGui { get; set; }
    }
}
