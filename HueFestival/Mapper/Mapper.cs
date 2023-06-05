using AutoMapper;
using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Mapper
{
    public class Mapper :  Profile
    {
        public   Mapper()
        {
            CreateMap<Account , AccountDTO>().ReverseMap();
            CreateMap<Check_in, Check_inDTO>().ReverseMap();
            CreateMap<ChiTiet_CTr, ChiTiet_CTrDTO>().ReverseMap();
            CreateMap<ChucVu, ChucVuDTO>().ReverseMap();
            CreateMap<ChuongTrinh, ChuongTrinhDTO>().ReverseMap();
            CreateMap<DiaDiem, DiaDiemDTO>().ReverseMap();
            CreateMap<DoanNT, DoanNTDTO>().ReverseMap();
            CreateMap<HinhAnh_CTr, HinhAnh_CTrDTO>().ReverseMap();
            CreateMap<HoTro, HoTroDTO>().ReverseMap();
            CreateMap<KhachHang, KhachHangDTO>().ReverseMap();
            CreateMap<Loai_DiaDiem, Loai_DiaDiemDTO>().ReverseMap();
            CreateMap<Loai_Ve, Loai_VeDTO>().ReverseMap();
            CreateMap<Nhom_CTr, Nhom_CTrDTO>().ReverseMap();
            CreateMap<ThongTin_Ve, ThongTin_VeDTO>().ReverseMap();
            CreateMap<TinTuc, TinTucDTO>().ReverseMap();
        }
    }
}
