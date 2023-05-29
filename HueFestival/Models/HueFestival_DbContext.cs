//using HueFestival.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Models
{
    public class HueFestival_DbContext : DbContext
    {
        public HueFestival_DbContext(DbContextOptions<HueFestival_DbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Check_in> Check_ins {get; set;}
        public DbSet<ChiTiet_CTr> ChiTiet_CTrs { get; set; }
        public DbSet<ChiTiet_DatVe> ChiTiet_DatVes { get; set; }
        public DbSet<ChuongTrinh> ChuongTrinhs { get; set; }
        public DbSet<ChucVu> ChucVus {get; set;}
        public DbSet<ChucNang> ChucNangs {get; set;}

        public DbSet<DiaDiem> DiaDiems { get; set; }
        public DbSet<DoanNT> DoanNTs { get; set; }

        public DbSet<HinhAnh_CTr> HinhAnh_CTrs { get; set; }
        public DbSet<HoTro> HoTros { get; set; }

        public DbSet<KhachHang> KhachHangs {get; set;}

        public DbSet<Loai_Ve> Loai_Ves { get; set; }
        public DbSet<Loai_DiaDiem> LoaiDiaDiems { get; set; }

        public DbSet<Nhom_CTr> Nhom_CTrs { get; set; }

        public DbSet<QuyenHanh> QuyenHanhs {get; set;}

        public DbSet<TinTuc> TinTucs { get; set; }
        public DbSet<ThongTin_Ve> ThongTin_Ves { get; set; }

        internal object GetDbContext()
        {
            throw new NotImplementedException();
        }
    }
}
