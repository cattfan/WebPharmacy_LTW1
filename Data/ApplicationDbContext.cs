using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebPharmacy.Areas.Identity;
using WebPharmacy.Models;

namespace WebPharmacy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Thuoc> Thuocs { get; set; }
        public DbSet<LoaiThuoc> LoaiThuocs { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<LienHe> LienHes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LoaiThuoc>().HasData(
                new LoaiThuoc { Id = 1, TenLoai = "Thuốc kháng sinh" },
                new LoaiThuoc { Id = 2, TenLoai = "Thuốc giảm đau" },
                new LoaiThuoc { Id = 3, TenLoai = "Vitamin và Khoáng chất" }
            );

            modelBuilder.Entity<Thuoc>().HasData(
                new Thuoc { Id = 1, TenThuoc = "Amoxicillin 500mg", MoTa = "Thuốc kháng sinh điều trị nhiễm khuẩn do vi khuẩn nhạy cảm gây ra.", Gia = 150000m, HinhAnhUrl = "https://placehold.co/500x500/28a745/white?text=Amoxicillin", LoaiThuocId = 1 },
                new Thuoc { Id = 2, TenThuoc = "Paracetamol 500mg", MoTa = "Thuốc giảm đau, hạ sốt hiệu quả và an toàn.", Gia = 50000m, HinhAnhUrl = "https://placehold.co/500x500/28a745/white?text=Paracetamol", LoaiThuocId = 2 },
                new Thuoc { Id = 3, TenThuoc = "Vitamin C 1000mg", MoTa = "Bổ sung Vitamin C, tăng cường hệ miễn dịch cho cơ thể.", Gia = 95000m, HinhAnhUrl = "https://placehold.co/500x500/28a745/white?text=Vitamin+C", LoaiThuocId = 3 },
                new Thuoc { Id = 4, TenThuoc = "Ibuprofen 400mg", MoTa = "Thuốc chống viêm không steroid, giảm đau, hạ sốt và chống viêm.", Gia = 75000m, HinhAnhUrl = "https://placehold.co/500x500/28a745/white?text=Ibuprofen", LoaiThuocId = 2 }
            );
        }
    }
}
