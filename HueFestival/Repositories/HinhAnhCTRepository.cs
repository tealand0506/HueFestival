using AutoMapper;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories
{
    public class HinhAnhCTRepository : Repository<HinhAnh_CTr>
    {
        private readonly HueFestival_DbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public HinhAnhCTRepository(HueFestival_DbContext context, IMapper mapper, IWebHostEnvironment environment) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<List<HinhAnh_CTr>> TatCaHinhAnhCuaCT(int id)
        {
            return await TruyXuatTheoLoai(ha => ha.ChuongTrinhs!);
        }
        public async Task<HinhAnh_CTr?> GetHinhAnhByID( int id)
        {
            var ha = await _dbSet.FirstOrDefaultAsync(ha => ha.IdHinhAnh == id);
            return ha;
        }
        public async Task<List<HinhAnh_CTr>> PostHinhAnhCT(HinhAnh_CTr ha)
        {
            List<HinhAnh_CTr> dsHinhAnh = new List<HinhAnh_CTr>();
            foreach(var file in ha.Path)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                InsertFile(file, imageName);
                var newImageEvent = new HinhAnh_CTr
                {
                    Path = "/images/" + imageName,
                    IdCtr = ha.IdHinhAnh
                };
                await PostAsync(newImageEvent);
                dsHinhAnh.Add(newImageEvent);
            }
            return dsHinhAnh;
        }
        public async Task UpdateImageEventAsync(HinhAnh_CTr CanSua, IFormFile file)
        {
            DeleteFile(CanSua.Path);

            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            InsertFile(file, imageName);

            var url = "/images/" + imageName;
            CanSua.Path = url;

            await PutAsync(CanSua);
        }
        public async Task DeleteHinhAnhCT(HinhAnh_CTr ha)
        {
            DeleteFile(ha.Path);
            await DeleteAsync(ha);
        }

        private void DeleteFile(string? imageUrl)
        {
            var imagePath = _environment.WebRootPath + imageUrl;
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        private async void InsertFile(IFormFile file, string imageName)
        {
            var newImagePath = _environment.WebRootPath + "\\images\\";
            if (!Directory.Exists(newImagePath))
            {
                Directory.CreateDirectory(newImagePath);
            }
            using (FileStream stream = System.IO.File.Create(newImagePath + imageName))
            {
                await file.CopyToAsync(stream);
                stream.Flush();
            }
        }
    }
}
