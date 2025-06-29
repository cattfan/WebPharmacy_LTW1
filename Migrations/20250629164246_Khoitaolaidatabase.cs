using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebPharmacy.Migrations
{
    /// <inheritdoc />
    public partial class Khoitaolaidatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LienHes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThuocs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thuocs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThuoc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HinhAnhUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThuocId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thuocs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thuocs_LoaiThuocs_LoaiThuocId",
                        column: x => x.LoaiThuocId,
                        principalTable: "LoaiThuocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ThuocId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Thuocs_ThuocId",
                        column: x => x.ThuocId,
                        principalTable: "Thuocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThuocId = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Thuocs_ThuocId",
                        column: x => x.ThuocId,
                        principalTable: "Thuocs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoaiThuocs",
                columns: new[] { "Id", "TenLoai" },
                values: new object[,]
                {
                    { 1, "Giảm Đau - Hạ Sốt" },
                    { 2, "Kháng Sinh - Kháng Viêm" },
                    { 3, "Ho - Cảm Cúm" },
                    { 4, "Vitamin & Khoáng Chất" },
                    { 5, "Tiêu Hóa" },
                    { 6, "Tim Mạch - Huyết Áp" },
                    { 7, "Dụng Cụ Y Tế" }
                });

            migrationBuilder.InsertData(
                table: "Thuocs",
                columns: new[] { "Id", "Gia", "HinhAnhUrl", "LoaiThuocId", "MoTa", "TenThuoc" },
                values: new object[,]
                {
                    { 1, 30000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00049_1_l.webp", 1, "Giảm nhanh các cơn đau và hạ sốt, chứa Paracetamol và Caffeine.", "Panadol Extra" },
                    { 2, 25000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00414_1_l.webp", 1, "Viên nén hạ sốt, giảm đau dành cho người lớn.", "Hapacol 650" },
                    { 3, 45000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00045_1_l.webp", 1, "Viên sủi giúp hạ sốt, giảm đau nhanh chóng.", "Efferalgan 500mg" },
                    { 4, 180000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P11933_1_l.webp", 2, "Kháng sinh phổ rộng điều trị nhiễm khuẩn đường hô hấp, tiết niệu.", "Augmentin 625mg" },
                    { 5, 38000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00021_1_l.webp", 2, "Thuốc kháng viêm, giảm phù nề sau chấn thương hoặc phẫu thuật.", "Alpha Choay" },
                    { 6, 110000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P01243_1.jpg", 2, "Thuốc chống viêm, chống dị ứng và ức chế miễn dịch.", "Medrol 16mg" },
                    { 7, 22000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P15582_1_l.webp", 3, "Giảm ho, long đờm hiệu quả.", "Terpin Codein" },
                    { 8, 95000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00320_1_l.webp", 3, "Điều trị các triệu chứng cảm thông thường: sốt, nhức đầu, sổ mũi.", "Decolgen Forte" },
                    { 9, 35000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00234_1_l.webp", 3, "Viên ngậm kháng khuẩn, làm dịu cơn đau họng.", "Strepsils Cool" },
                    { 10, 135000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00575_1_l.webp", 4, "Viên sủi bổ sung vitamin và khoáng chất, tăng cường năng lượng.", "Berocca Performance" },
                    { 11, 120000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P13997_1_l.webp", 4, "Bổ sung đầy đủ vitamin và khoáng chất cần thiết cho cơ thể.", "Supradyn" },
                    { 12, 165000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P17822_1_l.webp", 4, "Kết hợp nhân sâm G115 và vitamin, giúp giảm mệt mỏi.", "Pharmaton Energy" },
                    { 13, 115000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00223_1_l.webp", 5, "Điều trị tiêu chảy cấp và mạn tính ở người lớn và trẻ em.", "Smecta" },
                    { 14, 125000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00360_1_l.webp", 5, "Men vi sinh dạng ống giúp cân bằng hệ vi sinh đường ruột.", "Enterogermina" },
                    { 15, 90000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00196_1_l.webp", 5, "Thuốc chữ P, dạng gel giúp trung hòa acid dạ dày.", "Phosphalugel" },
                    { 16, 70000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P14917_1_l.webp", 6, "Thuốc điều trị tăng huyết áp và đau thắt ngực.", "Amlor 5mg" },
                    { 17, 130000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00685_1.jpg", 6, "Điều trị tăng huyết áp, suy tim mạn tính ổn định.", "Concor 5mg" },
                    { 18, 20000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P00267_1_l.webp", 7, "Băng keo thông thoáng, độ dính cao, bảo vệ các vết thương nhỏ.", "Băng keo cá nhân Urgo" },
                    { 19, 150000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P01535_1_l.webp", 7, "Đo nhiệt độ nhanh chóng, chính xác và an toàn.", "Nhiệt kế điện tử Omron" },
                    { 20, 5000m, "https://data-service.pharmacity.io/pmc-upload-media/production/pmc-ecm-core/products/P01579_1_l.webp", 7, "Dùng để rửa mắt, mũi, súc miệng hằng ngày.", "Nước muối sinh lý 0.9%" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ThuocId",
                table: "OrderDetails",
                column: "ThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ThuocId",
                table: "ShoppingCartItems",
                column: "ThuocId");

            migrationBuilder.CreateIndex(
                name: "IX_Thuocs_LoaiThuocId",
                table: "Thuocs",
                column: "LoaiThuocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LienHes");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Thuocs");

            migrationBuilder.DropTable(
                name: "LoaiThuocs");
        }
    }
}
