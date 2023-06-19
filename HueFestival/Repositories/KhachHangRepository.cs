using AutoMapper;
using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class KhachHangRepository : Repository<KhachHang>, IKhachHangRepository
    {
        private readonly HueFestival_DbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public KhachHangRepository(HueFestival_DbContext context, IMapper mapper, IWebHostEnvironment environment) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<List<KhachHang>> GetAllKhachHangAsync()
        {
            return await GetAllAsync();
        }
        public async Task<KhachHang?> GetByIdKhachHangAsync(int Id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.IdKhachHang == Id);

        }
        public async Task<KhachHang> PostKhachHangAsync(KhachHangDTO khDTO)
        {
            var themKhachHang = new KhachHang
            {
                HoTen = khDTO.HoTen,
                NgaySinh = khDTO.NgaySinh,
                SDT = khDTO.SDT,
                CCCD = khDTO.CCCD
            };
            await PostAsync(themKhachHang);
            return themKhachHang;
        }
        public async Task PutKhachHangAsync(KhachHang khCanSua, KhachHangDTO khMoi)
        {
            khCanSua.HoTen = khMoi.HoTen;
            khCanSua.NgaySinh = khMoi.NgaySinh;
            khCanSua.SDT = khMoi.SDT;
            khCanSua.CCCD = khMoi.CCCD;
            await PutAsync(khCanSua);
        }
        public async Task DeleteKhachHangAsync(KhachHang khCanXoa)
        {
            DeleteAsync(khCanXoa);
        }
    }
}
