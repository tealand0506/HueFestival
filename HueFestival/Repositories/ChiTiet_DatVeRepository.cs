using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HueFestival.Repositories
{
    public class ChiTiet_DatVeRepository : Repository<ChiTiet_DatVe>, IChiTiet_DatVeRepository
    {
        private readonly HueFestival_DbContext _context;
        public ChiTiet_DatVeRepository(HueFestival_DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ChiTiet_DatVe>> DSachDatVe()
        {
            return await GetAllAsync();
        }

        public async Task<object?> DatVe(ChiTiet_DatVeDTO datVeDTO)
        {
            string MaQRcode = TaoQRcode(datVeDTO.IdKhachHang, datVeDTO.IdKhachHang);
            var ThongTinVe = _context.ThongTin_Ves.FirstOrDefault(ve => ve.IdVe == datVeDTO.IdVe);
            if (ThongTinVe == null || ThongTinVe.SLg < datVeDTO.Slg)
            {
                return null;
            }
            else
            {
                ThongTinVe.SLg = ThongTinVe.SLg - datVeDTO.Slg;
                _context.SaveChanges();

                var datve = new ChiTiet_DatVe
                {
                    IdKhachHang = datVeDTO.IdKhachHang,
                    IdVe = datVeDTO.IdVe,
                    SLgVe = datVeDTO.Slg,
                    QRcode = MaQRcode,
                    ThanhTien = ThongTinVe.GiaVe * datVeDTO.Slg,
                };
                await PostAsync(datve);
                return datve;
            }
        }

        private string TaoQRcode(int IdKhachHang, int IdVe)
        {
            var combinedString = $"{IdKhachHang}{IdVe}";

            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(combinedString));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}
