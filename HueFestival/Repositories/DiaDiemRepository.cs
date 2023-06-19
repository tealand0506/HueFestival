using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using HueFestival.DataTransferObject;
using System.Xml.Linq;

namespace HueFestival.Repositories
{
    public class DiaDiemRepository : Repository<DiaDiem>, IDiaDiemRepository
    {
        private readonly HueFestival_DbContext _context;
        private readonly IWebHostEnvironment _environment;
        public DiaDiemRepository(HueFestival_DbContext context, IWebHostEnvironment environment) : base(context)
        {
            _context = context;
            _environment = environment;
        }


        public async Task<List<DiaDiem>> GetAllDiaDiemAsync()
        {
            return await TruyXuatTheoLoai(dd => dd.Loai_DiaDiems!);
            //return await GetAllAsync();
        }

        public async Task<DiaDiem> PostDiaDiemAsync(DiaDiemDTO diaDiemDTO)
        {
            //tao ten hinh anh duy nhat
            var TenHinhAnh = Guid.NewGuid().ToString() + Path.GetExtension(diaDiemDTO.PathImage?.FileName);
            ChenHinhAnh(diaDiemDTO.PathImage, TenHinhAnh);//luu hinh anh vao wwwroot

            var themDD = new DiaDiem
            {
                TenDiaDiem = diaDiemDTO.TenDiaDiem,
                MoTa = diaDiemDTO.MoTa,
                DiaChi = diaDiemDTO.DiaChi,
                PathImage = "/HinhAnhDiaDiem/" + TenHinhAnh,
                IdLoai_DD = diaDiemDTO.IdLoai_DD,
            };
            await PostAsync(themDD);

            return themDD;
        }

        public async Task PutDiaDiemAsync(DiaDiem DD_CanDoi, DiaDiemDTO DD_Moi)
        {
            //xoa hinh anh can doi      
            XoaHinhAnh(DD_CanDoi.PathImage);

            //tao ten hinh anh duy nhat
            var TenHinhAnh = Guid.NewGuid().ToString() + Path.GetExtension(DD_Moi.PathImage.FileName);

            ChenHinhAnh(DD_Moi.PathImage, TenHinhAnh);//luu hinh anh vao wwwroot

            //gan dia diem gtri mi cho dia diem can doi
            DD_CanDoi.TenDiaDiem = DD_Moi.TenDiaDiem;
            DD_CanDoi.MoTa = DD_Moi.MoTa;
            DD_CanDoi.DiaChi = DD_Moi.DiaChi;
            DD_CanDoi.PathImage = "/HinhAnhDiaDiem/" + TenHinhAnh;
            DD_CanDoi.IdLoai_DD = DD_Moi.IdLoai_DD;

            await PutAsync(DD_CanDoi); 
        }
        public async Task DeleteDiaDiemAsync(DiaDiem DD)
        {
            XoaHinhAnh(DD.PathImage);
            await DeleteAsync(DD);
        }
        public async Task<DiaDiem?> GetDiaDiemById(int Id)
        {
            var diaDiem = await _dbSet.FirstOrDefaultAsync(x => x.IdDiaDiem == Id);
            return diaDiem;
        }

        private void XoaHinhAnh(string? imageUrl) //xoa hinh anh khoi thu muc wwwroot/HinhAnhDiaDiem
        {
            var imagePath = _environment.WebRootPath + imageUrl;
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        private async void ChenHinhAnh(IFormFile? file, string TenHinhAnh)// luu hinh anh vao thu muc wwwroot/HinhAnhDiaDiem
        {
            var path = _environment.WebRootPath + "\\HinhAnhDiaDiem\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream stream = System.IO.File.Create(path + TenHinhAnh))
            {
                if (file != null)
                {
                    await file.CopyToAsync(stream);
                }
                stream.Flush();
            }
        }
    }
}
