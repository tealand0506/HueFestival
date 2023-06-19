using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival.Migrations
{
    /// <inheritdoc />
    public partial class updateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChiTiet_DatVe_IdVe",
                table: "ChiTiet_DatVe");

            migrationBuilder.AddColumn<int>(
                name: "ThanhTien",
                table: "ChiTiet_DatVe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_DatVe_IdVe",
                table: "ChiTiet_DatVe",
                column: "IdVe",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ChiTiet_DatVe_IdVe",
                table: "ChiTiet_DatVe");

            migrationBuilder.DropColumn(
                name: "ThanhTien",
                table: "ChiTiet_DatVe");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_DatVe_IdVe",
                table: "ChiTiet_DatVe",
                column: "IdVe");
        }
    }
}
