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

            // Seed LoaiThuoc
            modelBuilder.Entity<LoaiThuoc>().HasData(
                new LoaiThuoc { Id = 1, TenLoai = "Giảm Đau - Hạ Sốt" },
                new LoaiThuoc { Id = 2, TenLoai = "Kháng Sinh - Kháng Viêm" },
                new LoaiThuoc { Id = 3, TenLoai = "Ho - Cảm Cúm" },
                new LoaiThuoc { Id = 4, TenLoai = "Vitamin & Khoáng Chất" },
                new LoaiThuoc { Id = 5, TenLoai = "Tiêu Hóa" },
                new LoaiThuoc { Id = 6, TenLoai = "Tim Mạch - Huyết Áp" },
                new LoaiThuoc { Id = 7, TenLoai = "Dụng Cụ Y Tế" }
            );

            // Seed Thuoc
            modelBuilder.Entity<Thuoc>().HasData(
                // Giảm Đau - Hạ Sốt
                new Thuoc { Id = 1, TenThuoc = "Panadol Extra", MoTa = "Giảm nhanh các cơn đau và hạ sốt, chứa Paracetamol và Caffeine.", Gia = 30000m, LoaiThuocId = 1, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00049_1_l.webp" },
                new Thuoc { Id = 2, TenThuoc = "Hapacol 650", MoTa = "Viên nén hạ sốt, giảm đau dành cho người lớn.", Gia = 25000m, LoaiThuocId = 1, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00414_1_l.webp" },
                new Thuoc { Id = 3, TenThuoc = "Efferalgan 500mg", MoTa = "Viên sủi giúp hạ sốt, giảm đau nhanh chóng.", Gia = 45000m, LoaiThuocId = 1, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00045_1_l.webp" },

                // Kháng Sinh - Kháng Viêm
                new Thuoc { Id = 4, TenThuoc = "Augmentin 625mg", MoTa = "Kháng sinh phổ rộng điều trị nhiễm khuẩn đường hô hấp, tiết niệu.", Gia = 180000m, LoaiThuocId = 2, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P11933_1_l.webp" },
                new Thuoc { Id = 5, TenThuoc = "Alpha Choay", MoTa = "Thuốc kháng viêm, giảm phù nề sau chấn thương hoặc phẫu thuật.", Gia = 38000m, LoaiThuocId = 2, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00021_1_l.webp" },
                new Thuoc { Id = 6, TenThuoc = "Medrol 16mg", MoTa = "Thuốc chống viêm, chống dị ứng và ức chế miễn dịch.", Gia = 110000m, LoaiThuocId = 2, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P01243_1.jpg" },

                // Ho - Cảm Cúm
                new Thuoc { Id = 7, TenThuoc = "Terpin Codein", MoTa = "Giảm ho, long đờm hiệu quả.", Gia = 22000m, LoaiThuocId = 3, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P15582_1_l.webp" },
                new Thuoc { Id = 8, TenThuoc = "Decolgen Forte", MoTa = "Điều trị các triệu chứng cảm thông thường: sốt, nhức đầu, sổ mũi.", Gia = 95000m, LoaiThuocId = 3, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00320_1_l.webp" },
                new Thuoc { Id = 9, TenThuoc = "Strepsils Cool", MoTa = "Viên ngậm kháng khuẩn, làm dịu cơn đau họng.", Gia = 35000m, LoaiThuocId = 3, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00234_1_l.webp" },

                // Vitamin & Khoáng Chất
                new Thuoc { Id = 10, TenThuoc = "Berocca Performance", MoTa = "Viên sủi bổ sung vitamin và khoáng chất, tăng cường năng lượng.", Gia = 135000m, LoaiThuocId = 4, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00575_1_l.webp" },
                new Thuoc { Id = 11, TenThuoc = "Supradyn", MoTa = "Bổ sung đầy đủ vitamin và khoáng chất cần thiết cho cơ thể.", Gia = 120000m, LoaiThuocId = 4, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P13997_1_l.webp" },
                new Thuoc { Id = 12, TenThuoc = "Pharmaton Energy", MoTa = "Kết hợp nhân sâm G115 và vitamin, giúp giảm mệt mỏi.", Gia = 165000m, LoaiThuocId = 4, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P17822_1_l.webp" },

                // Tiêu Hóa
                new Thuoc { Id = 13, TenThuoc = "Smecta", MoTa = "Điều trị tiêu chảy cấp và mạn tính ở người lớn và trẻ em.", Gia = 115000m, LoaiThuocId = 5, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00223_1_l.webp" },
                new Thuoc { Id = 14, TenThuoc = "Enterogermina", MoTa = "Men vi sinh dạng ống giúp cân bằng hệ vi sinh đường ruột.", Gia = 125000m, LoaiThuocId = 5, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00360_1_l.webp" },
                new Thuoc { Id = 15, TenThuoc = "Phosphalugel", MoTa = "Thuốc chữ P, dạng gel giúp trung hòa acid dạ dày.", Gia = 90000m, LoaiThuocId = 5, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00196_1_l.webp" },

                // Tim Mạch - Huyết Áp
                new Thuoc { Id = 16, TenThuoc = "Amlor 5mg", MoTa = "Thuốc điều trị tăng huyết áp và đau thắt ngực.", Gia = 70000m, LoaiThuocId = 6, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P14917_1_l.webp" },
                new Thuoc { Id = 17, TenThuoc = "Concor 5mg", MoTa = "Điều trị tăng huyết áp, suy tim mạn tính ổn định.", Gia = 130000m, LoaiThuocId = 6, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00685_1.jpg" },

                // Dụng Cụ Y Tế
                new Thuoc { Id = 18, TenThuoc = "Băng keo cá nhân Urgo", MoTa = "Băng keo thông thoáng, độ dính cao, bảo vệ các vết thương nhỏ.", Gia = 20000m, LoaiThuocId = 7, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00267_1_l.webp" },
                new Thuoc { Id = 19, TenThuoc = "Nhiệt kế điện tử Omron", MoTa = "Đo nhiệt độ nhanh chóng, chính xác và an toàn.", Gia = 150000m, LoaiThuocId = 7, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P01535_1_l.webp" },
                new Thuoc { Id = 20, TenThuoc = "Nước muối sinh lý 0.9%", MoTa = "Dùng để rửa mắt, mũi, súc miệng hằng ngày.", Gia = 5000m, LoaiThuocId = 7, HinhAnhUrl = "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P01579_1_l.webp" }
            );
        }
    }
}
