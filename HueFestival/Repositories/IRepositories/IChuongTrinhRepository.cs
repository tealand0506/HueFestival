using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IChuongTrinhRepository : IRepository<ChuongTrinh>
    {
        Task<List<ChuongTrinh?>> GetAllChuongTrinh();
        Task<ChuongTrinh?> GetByIdChuongTrinh(int Id);
        Task<ChuongTrinh?> PostChuongTrinh(ChuongTrinhDTO ctDTO, List<IFormFile> dsHinhAnh);
        //Task PutChuongTrinh(ChuongTrinh CT);
        //Task DeleteChuongTrinh(ChuongTrinh CT);
    }
}
