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
                name: "Check_in",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDatVe = table.Column<int>(type: "int", nullable: false),
                    IdNhanVien = table.Column<int>(type: "int", nullable: false),
                    NgayCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check_in", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    IdChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.IdChucVu);
                });

            migrationBuilder.CreateTable(
                name: "ChuongTrinh",
                columns: table => new
                {
                    IdCTr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCtr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeInOff = table.Column<int>(type: "int", nullable: false),
                    Arrange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuongTrinh", x => x.IdCTr);
                });

            migrationBuilder.CreateTable(
                name: "DoanNT",
                columns: table => new
                {
                    IdDoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanNT", x => x.IdDoan);
                });

            migrationBuilder.CreateTable(
                name: "HoTro",
                columns: table => new
                {
                    IdHoTro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTroName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoTro", x => x.IdHoTro);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    IdKhachHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.IdKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "Loai_DiaDiem",
                columns: table => new
                {
                    IdLoai_DD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuaDe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai_DiaDiem", x => x.IdLoai_DD);
                });

            migrationBuilder.CreateTable(
                name: "Loai_Ve",
                columns: table => new
                {
                    IdLoai_Ve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiVe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai_Ve", x => x.IdLoai_Ve);
                });

            migrationBuilder.CreateTable(
                name: "Nhom_CTr",
                columns: table => new
                {
                    IdNhomCTr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhom_CTr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhom_CTr", x => x.IdNhomCTr);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
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
                    table.PrimaryKey("PK_TinTuc", x => x.IdTinTuc);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAcc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAcc);
                    table.ForeignKey(
                        name: "FK_Account_ChucVu_IdChucVu",
                        column: x => x.IdChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IdChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh_CTr",
                columns: table => new
                {
                    IdHinhAnh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCTr = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh_CTr", x => x.IdHinhAnh);
                    table.ForeignKey(
                        name: "FK_HinhAnh_CTr_ChuongTrinh_IdCTr",
                        column: x => x.IdCTr,
                        principalTable: "ChuongTrinh",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiaDiem",
                columns: table => new
                {
                    IdDiaDiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLoai_DD = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToaDoX = table.Column<double>(type: "float", nullable: true),
                    ToaDoY = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiem", x => x.IdDiaDiem);
                    table.ForeignKey(
                        name: "FK_DiaDiem_Loai_DiaDiem_IdLoai_DD",
                        column: x => x.IdLoai_DD,
                        principalTable: "Loai_DiaDiem",
                        principalColumn: "IdLoai_DD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTin_Ve",
                columns: table => new
                {
                    IdVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SLg = table.Column<int>(type: "int", nullable: false),
                    GiaVe = table.Column<int>(type: "int", nullable: false),
                    NgayPhatHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLoai_Ve = table.Column<int>(type: "int", nullable: false),
                    IdCTr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTin_Ve", x => x.IdVe);
                    table.ForeignKey(
                        name: "FK_ThongTin_Ve_ChuongTrinh_IdCTr",
                        column: x => x.IdCTr,
                        principalTable: "ChuongTrinh",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTin_Ve_Loai_Ve_IdLoai_Ve",
                        column: x => x.IdLoai_Ve,
                        principalTable: "Loai_Ve",
                        principalColumn: "IdLoai_Ve",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_CTr",
                columns: table => new
                {
                    IdChiTiet_Ctr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCTr = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    fDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDiaDiem = table.Column<int>(type: "int", nullable: false),
                    IdDoan = table.Column<int>(type: "int", nullable: false),
                    IdNhomCTr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_CTr", x => x.IdChiTiet_Ctr);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_ChuongTrinh_IdCTr",
                        column: x => x.IdCTr,
                        principalTable: "ChuongTrinh",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_DiaDiem_IdDiaDiem",
                        column: x => x.IdDiaDiem,
                        principalTable: "DiaDiem",
                        principalColumn: "IdDiaDiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_DoanNT_IdDoan",
                        column: x => x.IdDoan,
                        principalTable: "DoanNT",
                        principalColumn: "IdDoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_Nhom_CTr_IdNhomCTr",
                        column: x => x.IdNhomCTr,
                        principalTable: "Nhom_CTr",
                        principalColumn: "IdNhomCTr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_DatVe",
                columns: table => new
                {
                    IdDatVe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVe = table.Column<int>(type: "int", nullable: false),
                    IdKhachHang = table.Column<int>(type: "int", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SLgVe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_DatVe", x => x.IdDatVe);
                    table.ForeignKey(
                        name: "FK_ChiTiet_DatVe_KhachHang_IdKhachHang",
                        column: x => x.IdKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_DatVe_ThongTin_Ve_IdVe",
                        column: x => x.IdVe,
                        principalTable: "ThongTin_Ve",
                        principalColumn: "IdVe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_IdChucVu",
                table: "Account",
                column: "IdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_IdCTr",
                table: "ChiTiet_CTr",
                column: "IdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_IdDiaDiem",
                table: "ChiTiet_CTr",
                column: "IdDiaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_IdDoan",
                table: "ChiTiet_CTr",
                column: "IdDoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_IdNhomCTr",
                table: "ChiTiet_CTr",
                column: "IdNhomCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_DatVe_IdKhachHang",
                table: "ChiTiet_DatVe",
                column: "IdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_DatVe_IdVe",
                table: "ChiTiet_DatVe",
                column: "IdVe");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiem_IdLoai_DD",
                table: "DiaDiem",
                column: "IdLoai_DD");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_CTr_IdCTr",
                table: "HinhAnh_CTr",
                column: "IdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTin_Ve_IdCTr",
                table: "ThongTin_Ve",
                column: "IdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTin_Ve_IdLoai_Ve",
                table: "ThongTin_Ve",
                column: "IdLoai_Ve");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Check_in");

            migrationBuilder.DropTable(
                name: "ChiTiet_CTr");

            migrationBuilder.DropTable(
                name: "ChiTiet_DatVe");

            migrationBuilder.DropTable(
                name: "HinhAnh_CTr");

            migrationBuilder.DropTable(
                name: "HoTro");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "DiaDiem");

            migrationBuilder.DropTable(
                name: "DoanNT");

            migrationBuilder.DropTable(
                name: "Nhom_CTr");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "ThongTin_Ve");

            migrationBuilder.DropTable(
                name: "Loai_DiaDiem");

            migrationBuilder.DropTable(
                name: "ChuongTrinh");

            migrationBuilder.DropTable(
                name: "Loai_Ve");
        }
    }
}
