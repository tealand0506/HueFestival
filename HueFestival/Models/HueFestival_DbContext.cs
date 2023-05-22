//using HueFestival.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Models
{
    public class HueFestival_DbContext : DbContext
    {
        public HueFestival_DbContext(DbContextOptions<HueFestival_DbContext> options) : base(options) { }

        public DbSet<ChiTiet_CTr> ChiTiet_CTrs { get; set; }
        public DbSet<ChiTiet_DatVe> ChiTiet_DatVes { get; set; }
        public DbSet<ChuongTrinh> ChuongTrinhs { get; set; }
        public DbSet<DiaDiem> DiaDiems { get; set; }
        public DbSet<HinhAnh_CTr> HinhAnh_CTrs { get; set; }
        public DbSet<DoanNT> DoanNTs { get; set; }
        public DbSet<HoTro> HoTros { get; set; }
        public DbSet<Loai_Ve> Loai_Ves { get; set; }
        public DbSet<LoaiDiaDiem> LoaiDiaDiems { get; set; }
        public DbSet<Nhom_CTr> Nhom_CTrs { get; set; }
        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<Ve> Ves { get; set; }
    }
}
