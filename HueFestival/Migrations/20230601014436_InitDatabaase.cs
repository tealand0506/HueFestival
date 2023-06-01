using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueFestival.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabaase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucNang",
                columns: table => new
                {
                    IdchucNang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucNang = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucNang", x => x.IdchucNang);
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
                    GiaTien = table.Column<double>(type: "float", nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    IdLoai_ve = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiVe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai_VeIdLoai_ve = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loai_Ve", x => x.IdLoai_ve);
                    table.ForeignKey(
                        name: "FK_Loai_Ve_Loai_Ve_Loai_VeIdLoai_ve",
                        column: x => x.Loai_VeIdLoai_ve,
                        principalTable: "Loai_Ve",
                        principalColumn: "IdLoai_ve");
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
                    IdChucVu = table.Column<int>(type: "int", nullable: false),
                    ChucVusIdChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAcc);
                    table.ForeignKey(
                        name: "FK_Account_ChucVu_ChucVusIdChucVu",
                        column: x => x.ChucVusIdChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IdChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Check_in",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKhachHang = table.Column<int>(type: "int", nullable: false),
                    IdNhanVien = table.Column<int>(type: "int", nullable: false),
                    NgayCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChucNangsIdchucNang = table.Column<int>(type: "int", nullable: false),
                    ChucVusIdChucVu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check_in", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Check_in_ChucNang_ChucNangsIdchucNang",
                        column: x => x.ChucNangsIdchucNang,
                        principalTable: "ChucNang",
                        principalColumn: "IdchucNang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Check_in_ChucVu_ChucVusIdChucVu",
                        column: x => x.ChucVusIdChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "IdChucVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyenHanh",
                columns: table => new
                {
                    IdQuyenHanh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdChucVu = table.Column<int>(type: "int", nullable: false),
                    IdChucNang = table.Column<int>(type: "int", nullable: false),
                    ChucVusIdChucVu = table.Column<int>(type: "int", nullable: false),
                    ChucNangsIdchucNang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHanh", x => x.IdQuyenHanh);
                    table.ForeignKey(
                        name: "FK_QuyenHanh_ChucNang_ChucNangsIdchucNang",
                        column: x => x.ChucNangsIdchucNang,
                        principalTable: "ChucNang",
                        principalColumn: "IdchucNang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuyenHanh_ChucVu_ChucVusIdChucVu",
                        column: x => x.ChucVusIdChucVu,
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
                    IdCtr = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuongTrinhsIdCTr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh_CTr", x => x.IdHinhAnh);
                    table.ForeignKey(
                        name: "FK_HinhAnh_CTr_ChuongTrinh_ChuongTrinhsIdCTr",
                        column: x => x.ChuongTrinhsIdCTr,
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
                    IdLoaiDD = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToaDoX = table.Column<double>(type: "float", nullable: true),
                    ToaDoY = table.Column<double>(type: "float", nullable: true),
                    LoaiDiaDiemsIdLoai_DD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiem", x => x.IdDiaDiem);
                    table.ForeignKey(
                        name: "FK_DiaDiem_Loai_DiaDiem_LoaiDiaDiemsIdLoai_DD",
                        column: x => x.LoaiDiaDiemsIdLoai_DD,
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
                    IdLoai_ve = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IdChuongTrinh = table.Column<int>(type: "int", nullable: false),
                    SLg = table.Column<int>(type: "int", nullable: false),
                    GiaVe = table.Column<int>(type: "int", nullable: false),
                    NgayPhatHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Loai_VesIdLoai_ve = table.Column<int>(type: "int", nullable: false),
                    ChuongTrinhsIdCTr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTin_Ve", x => x.IdVe);
                    table.ForeignKey(
                        name: "FK_ThongTin_Ve_ChuongTrinh_ChuongTrinhsIdCTr",
                        column: x => x.ChuongTrinhsIdCTr,
                        principalTable: "ChuongTrinh",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTin_Ve_Loai_Ve_Loai_VesIdLoai_ve",
                        column: x => x.Loai_VesIdLoai_ve,
                        principalTable: "Loai_Ve",
                        principalColumn: "IdLoai_ve",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTiet_CTr",
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
                    table.PrimaryKey("PK_ChiTiet_CTr", x => x.IdChiTiet_Ctr);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_ChuongTrinh_ChuongTrinhsIdCTr",
                        column: x => x.ChuongTrinhsIdCTr,
                        principalTable: "ChuongTrinh",
                        principalColumn: "IdCTr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_DiaDiem_DiaDiemsIdDiaDiem",
                        column: x => x.DiaDiemsIdDiaDiem,
                        principalTable: "DiaDiem",
                        principalColumn: "IdDiaDiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_DoanNT_DoanNTsIdDoan",
                        column: x => x.DoanNTsIdDoan,
                        principalTable: "DoanNT",
                        principalColumn: "IdDoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_CTr_Nhom_CTr_Nhom_CTrsIdNhomCTr",
                        column: x => x.Nhom_CTrsIdNhomCTr,
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
                    SLgVe = table.Column<int>(type: "int", nullable: false),
                    ThongTin_VesIdVe = table.Column<int>(type: "int", nullable: false),
                    KhachHangsIdKhachHang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTiet_DatVe", x => x.IdDatVe);
                    table.ForeignKey(
                        name: "FK_ChiTiet_DatVe_KhachHang_KhachHangsIdKhachHang",
                        column: x => x.KhachHangsIdKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "IdKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTiet_DatVe_ThongTin_Ve_ThongTin_VesIdVe",
                        column: x => x.ThongTin_VesIdVe,
                        principalTable: "ThongTin_Ve",
                        principalColumn: "IdVe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_ChucVusIdChucVu",
                table: "Account",
                column: "ChucVusIdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_Check_in_ChucNangsIdchucNang",
                table: "Check_in",
                column: "ChucNangsIdchucNang");

            migrationBuilder.CreateIndex(
                name: "IX_Check_in_ChucVusIdChucVu",
                table: "Check_in",
                column: "ChucVusIdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_ChuongTrinhsIdCTr",
                table: "ChiTiet_CTr",
                column: "ChuongTrinhsIdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_DiaDiemsIdDiaDiem",
                table: "ChiTiet_CTr",
                column: "DiaDiemsIdDiaDiem");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_DoanNTsIdDoan",
                table: "ChiTiet_CTr",
                column: "DoanNTsIdDoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_CTr_Nhom_CTrsIdNhomCTr",
                table: "ChiTiet_CTr",
                column: "Nhom_CTrsIdNhomCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_DatVe_KhachHangsIdKhachHang",
                table: "ChiTiet_DatVe",
                column: "KhachHangsIdKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTiet_DatVe_ThongTin_VesIdVe",
                table: "ChiTiet_DatVe",
                column: "ThongTin_VesIdVe");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDiem_LoaiDiaDiemsIdLoai_DD",
                table: "DiaDiem",
                column: "LoaiDiaDiemsIdLoai_DD");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_CTr_ChuongTrinhsIdCTr",
                table: "HinhAnh_CTr",
                column: "ChuongTrinhsIdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_Loai_Ve_Loai_VeIdLoai_ve",
                table: "Loai_Ve",
                column: "Loai_VeIdLoai_ve");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenHanh_ChucNangsIdchucNang",
                table: "QuyenHanh",
                column: "ChucNangsIdchucNang");

            migrationBuilder.CreateIndex(
                name: "IX_QuyenHanh_ChucVusIdChucVu",
                table: "QuyenHanh",
                column: "ChucVusIdChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTin_Ve_ChuongTrinhsIdCTr",
                table: "ThongTin_Ve",
                column: "ChuongTrinhsIdCTr");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTin_Ve_Loai_VesIdLoai_ve",
                table: "ThongTin_Ve",
                column: "Loai_VesIdLoai_ve");
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
                name: "QuyenHanh");

            migrationBuilder.DropTable(
                name: "TinTuc");

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
                name: "ChucNang");

            migrationBuilder.DropTable(
                name: "ChucVu");

            migrationBuilder.DropTable(
                name: "Loai_DiaDiem");

            migrationBuilder.DropTable(
                name: "ChuongTrinh");

            migrationBuilder.DropTable(
                name: "Loai_Ve");
        }
    }
}
