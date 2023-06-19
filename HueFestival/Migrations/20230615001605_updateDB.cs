using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaVe",
                table: "ThongTin_Ve");

            migrationBuilder.AddColumn<string>(
                name: "QRcode",
                table: "ChiTiet_DatVe",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QRcode",
                table: "ChiTiet_DatVe");

            migrationBuilder.AddColumn<string>(
                name: "MaVe",
                table: "ThongTin_Ve",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
