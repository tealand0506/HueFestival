using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class NguoiDungRepository : Repository<NguoiDung>, INguoiDungRepository
    {
        private readonly HueFestival_DbContext _context;
        public NguoiDungRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<NguoiDung>> GetNguoiDungByChucVuAsync ()
        {
            return await TruyXuatTheoLoai(nd => nd.ChucVus);
        }

        public async Task<NguoiDung?> GetNguoiDungbyIdAsync(int id)
        {
            return await GetById(id);
        }

        public async Task<NguoiDung> PostNguoiDungAsync(NguoiDungDTO ndDTO, int idAcc)
        {
            var themNguoiDung = new NguoiDung
            {
                HoTen = ndDTO.HoTen,
                SDT = ndDTO.SDT,
                Email = ndDTO.Email,
                IdChucVu = ndDTO.IdChucVu,
                IdAccount = idAcc,
            };

            await PostAsync(themNguoiDung);
            return themNguoiDung;
        }
        
    }
}