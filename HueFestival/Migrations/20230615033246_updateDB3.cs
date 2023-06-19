using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival.Migrations
{
    /// <inheritdoc />
    public partial class updateDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Check_in_IdDatVe",
                table: "Check_in",
                column: "IdDatVe");

            migrationBuilder.AddForeignKey(
                name: "FK_Check_in_ChiTiet_DatVe_IdDatVe",
                table: "Check_in",
                column: "IdDatVe",
                principalTable: "ChiTiet_DatVe",
                principalColumn: "IdDatVe",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Check_in_ChiTiet_DatVe_IdDatVe",
                table: "Check_in");

            migrationBuilder.DropIndex(
                name: "IX_Check_in_IdDatVe",
                table: "Check_in");
        }
    }
}
