using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival.Migrations
{
    /// <inheritdoc />
    public partial class initDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiTiet_DatVes",
                columns: table => new
                {
                    IdDatVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVe = table.Column<int>(type: "int", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_DatVes", x => x.IdDatVe);
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinhs",
                columns: table => new
                {
                    IdCTr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCtr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GiaTien = table.Column<double>(type: "float", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeInOff = table.Column<int>(type: "int", nullable: false),
                    Arrange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinhs", x => x.IdCTr);
                });

            migrationBuilder.CreateTable(
                name: "DoanNTs",
                columns: table => new
                {
                    IdDoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanNTs", x => x.IdDoan);
                });

            migrationBuilder.CreateTable(
                name: "HoTros",
                columns: table => new
                {
                    IdHoTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoTros", x => x.IdHoTro);
                });

            migrationBuilder.CreateTable(
                name: "Loai_Ves",
                columns: table => new
                {
                    IdLoai_ve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiVe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai_VeIdLoai_ve = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai_Ves", x => x.IdLoai_ve);
                    table.ForeignKey(
                        name: "FK_Loai_Ves_Loai_Ves_Loai_VeIdLoai_ve",
                        column: x => x.Loai_VeIdLoai_ve,
                        principalTable: "Loai_Ves",
                        principalColumn: "IdLoai_ve");
                });

            migrationBuilder.CreateTable(
                name: "Nhom_CTrs",
                columns: table => new
                {
                    IdNhomCTr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhom_CTr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhom_CTrs", x => x.IdNhomCTr);
                });

            migrationBuilder.CreateTable(
                name: "TinTucs",
                columns: table => new
                {
                    IdTinTuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TacGia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTucs", x => x.IdTinTuc);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh_CTrs",
                columns: table => new
                {
                    IdHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCtr = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuongTrinhsIdCTr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh_CTrs", x => x.IdHinhAnh);
                    table.ForeignKey(
                        name: "FK_HinhAnh_CTrs_ChuongTrinhs_ChuongTrinhsIdCTr",
                        column: x => x.ChuongTrinhsIdCTr,
                        principalTable: "ChuongTrinhs",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_CTrs",
                columns: table => new
                {
                    IdChiTiet_Ctr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCtr = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    fDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDiaDiem = table.Column<int>(type: "int", nullable: false),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDoan = table.Column<int>(type: "int", nullable: false),
                    TenDoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNhomCTr = table.Column<int>(type: "int", nullable: false),
                    TenNhom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuongTrinhsIdCTr = table.Column<int>(type: "int", nullable: false),
                    DiaDiemsIdDiaDiem = table.Column<int>(type: "int", nullable: false),
                    Nhom_CTrsIdNhomCTr = table.Column<int>(type: "int", nullable: false),
                    DoanNTsIdDoan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_CTrs", x => x.IdChiTiet_Ctr);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTrs_ChuongTrinhs_ChuongTrinhsIdCTr",
                        column: x => x.ChuongTrinhsIdCTr,
                        principalTable: "ChuongTrinhs",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTrs_DoanNTs_DoanNTsIdDoan",
                        column: x => x.DoanNTsIdDoan,
                        principalTable: "DoanNTs",
                        principalColumn: "IdDoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTrs_Nhom_CTrs_Nhom_CTrsIdNhomCTr",
                        column: x => x.Nhom_CTrsIdNhomCTr,
                        principalTable: "Nhom_CTrs",
                        principalColumn: "IdNhomCTr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDiaDiems",
                columns: table => new
                {
                    IdLoaiDD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiTiet_CTrsIdChiTiet_Ctr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDiaDiems", x => x.IdLoaiDD);
                    table.ForeignKey(
                        name: "FK_LoaiDiaDiems_ChiTiet_CTrs_ChiTiet_CTrsIdChiTiet_Ctr",
                        column: x => x.ChiTiet_CTrsIdChiTiet_Ctr,
                        principalTable: "ChiTiet_CTrs",
                        principalColumn: "IdChiTiet_Ctr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ves",
                columns: table => new
                {
                    IdVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLoai_ve = table.Column<int>(type: "int", nullable: false),
                    IdChiTiet_Ctr = table.Column<int>(type: "int", nullable: false),
                    SLg = table.Column<int>(type: "int", nullable: false),
                    GiaVe = table.Column<int>(type: "int", nullable: false),
                    NgayPhatHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Loai_VesIdLoai_ve = table.Column<int>(type: "int", nullable: false),
                    ChiTiet_CTrsIdChiTiet_Ctr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ves", x => x.IdVe);
                    table.ForeignKey(
                        name: "FK_Ves_ChiTiet_CTrs_ChiTiet_CTrsIdChiTiet_Ctr",
                        column: x => x.ChiTiet_CTrsIdChiTiet_Ctr,
                        principalTable: "ChiTiet_CTrs",
                        principalColumn: "IdChiTiet_Ctr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ves_Loai_Ves_Loai_VesIdLoai_ve",
                        column: x => x.Loai_VesIdLoai_ve,
                        principalTable: "Loai_Ves",
                        principalColumn: "IdLoai_ve",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiems",
                columns: table => new
                {
                    IdDiaDiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLoaiDD = table.Column<int>(type: "int", nullable: false),
                    TomTat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToaDoX = table.Column<double>(type: "float", nullable: false),
                    ToaDoY = table.Column<double>(type: "float", nullable: false),
                    LoaiDiaDiemsIdLoaiDD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiems", x => x.IdDiaDiem);
                    table.ForeignKey(
                        name: "FK_DiaDiems_LoaiDiaDiems_LoaiDiaDiemsIdLoaiDD",
                        column: x => x.LoaiDiaDiemsIdLoaiDD,
                        principalTable: "LoaiDiaDiems",
                        principalColumn: "IdLoaiDD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTrs_ChuongTrinhsIdCTr",
                table: "ChiTiet_CTrs",
                column: "ChuongTrinhsIdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTrs_DiaDiemsIdDiaDiem",
                table: "ChiTiet_CTrs",
                column: "DiaDiemsIdDiaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTrs_DoanNTsIdDoan",
                table: "ChiTiet_CTrs",
                column: "DoanNTsIdDoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTrs_Nhom_CTrsIdNhomCTr",
                table: "ChiTiet_CTrs",
                column: "Nhom_CTrsIdNhomCTr");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiems_LoaiDiaDiemsIdLoaiDD",
                table: "DiaDiems",
                column: "LoaiDiaDiemsIdLoaiDD");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_CTrs_ChuongTrinhsIdCTr",
                table: "HinhAnh_CTrs",
                column: "ChuongTrinhsIdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_Ves_Loai_VeIdLoai_ve",
                table: "Loai_Ves",
                column: "Loai_VeIdLoai_ve");

            migrationBuilder.CreateIndex(
                name: "IX_LoaiDiaDiems_ChiTiet_CTrsIdChiTiet_Ctr",
                table: "LoaiDiaDiems",
                column: "ChiTiet_CTrsIdChiTiet_Ctr");

            migrationBuilder.CreateIndex(
                name: "IX_Ves_ChiTiet_CTrsIdChiTiet_Ctr",
                table: "Ves",
                column: "ChiTiet_CTrsIdChiTiet_Ctr");

            migrationBuilder.CreateIndex(
                name: "IX_Ves_Loai_VesIdLoai_ve",
                table: "Ves",
                column: "Loai_VesIdLoai_ve");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTiet_CTrs_DiaDiems_DiaDiemsIdDiaDiem",
                table: "ChiTiet_CTrs",
                column: "DiaDiemsIdDiaDiem",
                principalTable: "DiaDiems",
                principalColumn: "IdDiaDiem",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_CTrs_ChuongTrinhs_ChuongTrinhsIdCTr",
                table: "ChiTiet_CTrs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChiTiet_CTrs_DiaDiems_DiaDiemsIdDiaDiem",
                table: "ChiTiet_CTrs");

            migrationBuilder.DropTable(
                name: "ChiTiet_DatVes");

            migrationBuilder.DropTable(
                name: "HinhAnh_CTrs");

            migrationBuilder.DropTable(
                name: "HoTros");

            migrationBuilder.DropTable(
                name: "TinTucs");

            migrationBuilder.DropTable(
                name: "Ves");

            migrationBuilder.DropTable(
                name: "Loai_Ves");

            migrationBuilder.DropTable(
                name: "ChuongTrinhs");

            migrationBuilder.DropTable(
                name: "DiaDiems");

            migrationBuilder.DropTable(
                name: "LoaiDiaDiems");

            migrationBuilder.DropTable(
                name: "ChiTiet_CTrs");

            migrationBuilder.DropTable(
                name: "DoanNTs");

            migrationBuilder.DropTable(
                name: "Nhom_CTrs");
        }
    }
}
