using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IHinhAnhCTRepository : IRepository<HinhAnh_CTr>
    {
        Task<List<HinhAnh_CTr>> TatCaHinhAnhCuaCT(int IdCT);// xem tat ca hinh anh cua chuong tirnh
        Task<HinhAnh_CTr?> GetHinhAnhByID(int Id);
        Task<HinhAnh_CTr> PostHinhAnhCT(HinhAnh_CTr ha);//them hinh anh cho chuong tirnh
        Task PutHinhAnhCT(HinhAnh_CTr haCanSua, IFormFile file);//swa hinh anh cua chuong trinh
        Task DeleteHinhAnhCT(HinhAnh_CTr ha);//xa hinh anh cua chung trinh
    }
}
