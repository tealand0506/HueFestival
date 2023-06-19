﻿using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;

namespace HueFestival.Repositories
{
    public class VeRepository : Repository<ThongTin_Ve>, IVeRepository
    {
        private readonly HueFestival_DbContext _context;
        public VeRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ThongTin_Ve>> DanhSachThongTinVe()
        {
            //return await TruyXuatTheoLoai(ve => ve.IdCTr);
            return await GetAllAsync();
        }
        public async Task<ThongTin_Ve?> GetByIdThongTinVe(int id)
        {
            return await GetByIdThongTinVe(id);
        }
        public async Task<ThongTin_Ve> PostThongTinVe(ThongTin_VeDTO VeDTO)
        {
            var PhatHanhVe = new ThongTin_Ve
            {

                IdCTr = VeDTO.IdCTr,
                IdLoai_Ve = VeDTO.IdLoai_ve,
                GiaVe = VeDTO.GiaVe,
                SLg = VeDTO.SLg,
                Status = VeDTO.Status
            };
            await PostAsync(PhatHanhVe);
            return PhatHanhVe;
        }
        public async Task PutThongTinVe(ThongTin_VeDTO VeCanSua, ThongTin_VeDTO VeMoi)
        {

        }
        public async Task DeleteThongTinVe(ThongTin_VeDTO VeCanXoa)
        {

        }
    }
}
