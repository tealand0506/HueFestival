using HueFestival.Models;
using HueFestival.DataTransferObject;

namespace HueFestival.Repositories.IRepositories
{
    public interface IHinhAnhCTRepository : IRepository<HinhAnh_CTr>
    {
        Task<List<HinhAnh_CTr>> TatCaHinhAnh();// xem tat ca hinh anh cua chuong tirnh
        Task<List<HinhAnh_CTr?>> GetHinhAnhByCT(int idCT);
        Task<List<HinhAnh_CTr>> PostHinhAnhCT(HinhAnh_CTrDTO ha);//them hinh anh cho chuong tirnh
        Task UpdateImageEventAsync(HinhAnh_CTr CanSua, IFormFile file);//swa hinh anh cua chuong trinh
        Task DeleteHinhAnhCT(HinhAnh_CTr ha);//xa hinh anh cua chung trinh
    }
}
