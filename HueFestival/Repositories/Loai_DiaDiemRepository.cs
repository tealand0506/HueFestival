using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class Loai_DiaDiemRepository : Repository<Loai_DiaDiem>, ILoai_DiaDiemRepository
    {
        private readonly HueFestival_DbContext _context;
        private readonly IWebHostEnvironment _environment;
        public Loai_DiaDiemRepository(HueFestival_DbContext context, IWebHostEnvironment environment) : base(context)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<List<Loai_DiaDiem>> GetAllLoai_DiaDiemAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Loai_DiaDiem?> GetByIdLoai_DiaDiemAsync(int IdLoai_DD)
        {
            var ldd = await _dbSet.FirstOrDefaultAsync(x => x.IdLoai_DD == IdLoai_DD);
            return ldd;
        }
        public async Task<Loai_DiaDiem> PostLoai_DiaDiemAsync(Loai_DiaDiemDTO lddDTO)
        {
            var TenHinhAnh = Guid.NewGuid().ToString() + Path.GetExtension(lddDTO.PathImage?.FileName);
            ChenHinhAnh(lddDTO.PathImage, TenHinhAnh);//luu hinh anh vao wwwroot

            var themLoai_DiaDiem = new Loai_DiaDiem
            {
                TuaDe = lddDTO.TuaDe,
                PathImage = "/HinhAnhDiaDiem/" + TenHinhAnh,
            };
            await PostAsync(themLoai_DiaDiem);
            return themLoai_DiaDiem;
        }
        public async Task PutLoai_DiaDiemAsync(Loai_DiaDiem ldd_CanDoi, Loai_DiaDiemDTO ldd_Moi)
        {
            //xoa hinh anh can doi      
            XoaHinhAnh(ldd_CanDoi.PathImage);

            //tao ten hinh anh duy nhat
            var TenHinhAnh = Guid.NewGuid().ToString() + Path.GetExtension(ldd_Moi.PathImage.FileName);

            ChenHinhAnh(ldd_Moi.PathImage, TenHinhAnh);//luu hinh anh vao wwwroot


            ldd_CanDoi.TuaDe = ldd_Moi.TuaDe;
            ldd_CanDoi.PathImage = "/HinhAnhDiaDiem/" + TenHinhAnh;

            await PutAsync(ldd_CanDoi);
        }
        public async Task DeleteLoai_DiaDiemAsync(Loai_DiaDiem ldd)
        {
            XoaHinhAnh(ldd.PathImage);
            await DeleteAsync(ldd);
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
