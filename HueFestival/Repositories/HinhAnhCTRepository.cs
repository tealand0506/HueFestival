using AutoMapper;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using HueFestival.DataTransferObject;


namespace HueFestival.Repositories
{
    public class HinhAnhCTRepository : Repository<HinhAnh_CTr>, IHinhAnhCTRepository
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

        public async Task<List<HinhAnh_CTr>> TatCaHinhAnh()
        {
            return await TruyXuatTheoLoai(ha => ha.ChuongTrinhs!);
        }
        public async Task<List<HinhAnh_CTr?>> GetHinhAnhByCT( int idCT)
        {
            var dsHinhAnh = await _dbSet.Where(ha => ha.IdCTr == idCT).ToListAsync();
            return dsHinhAnh;
        }
        public async Task<List<HinhAnh_CTr>> PostHinhAnhCT(HinhAnh_CTrDTO HinhAnhDTO)
        {
            List<HinhAnh_CTr> dsHinhAnh = new List<HinhAnh_CTr>();
            foreach(var file in HinhAnhDTO.Path!)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                InsertFile(file, imageName);
                var newImageEvent = new HinhAnh_CTr
                {
                    Path = "/HinhAnhChuongTrinh/" + imageName,
                    IdCTr = HinhAnhDTO.IdCTr
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
