using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebPharmacy.Migrations
{
    /// <inheritdoc />
    public partial class Khoitaodatabasevoidulieumau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "LoaiThuocs",
                columns: new[] { "Id", "TenLoai" },
                values: new object[,]
                {
                    { 1, "Thuốc kháng sinh" },
                    { 2, "Thuốc giảm đau" },
                    { 3, "Vitamin và Khoáng chất" }
                });

            migrationBuilder.InsertData(
                table: "Thuocs",
                columns: new[] { "Id", "Gia", "HinhAnhUrl", "LoaiThuocId", "MoTa", "TenThuoc" },
                values: new object[,]
                {
                    { 1, 150000m, "https://placehold.co/500x500/28a745/white?text=Amoxicillin", 1, "Thuốc kháng sinh điều trị nhiễm khuẩn do vi khuẩn nhạy cảm gây ra.", "Amoxicillin 500mg" },
                    { 2, 50000m, "https://placehold.co/500x500/28a745/white?text=Paracetamol", 2, "Thuốc giảm đau, hạ sốt hiệu quả và an toàn.", "Paracetamol 500mg" },
                    { 3, 95000m, "https://placehold.co/500x500/28a745/white?text=Vitamin+C", 3, "Bổ sung Vitamin C, tăng cường hệ miễn dịch cho cơ thể.", "Vitamin C 1000mg" },
                    { 4, 75000m, "https://placehold.co/500x500/28a745/white?text=Ibuprofen", 2, "Thuốc chống viêm không steroid, giảm đau, hạ sốt và chống viêm.", "Ibuprofen 400mg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Thuocs_LoaiThuocId",
                table: "Thuocs",
                column: "LoaiThuocId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thuocs");

            migrationBuilder.DropTable(
                name: "LoaiThuocs");
        }
    }
}
