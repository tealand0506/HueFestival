using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using HueFestival.Repository.IRepository;

namespace HueFestival.Repositories.IRepositories
{
    public interface IChucNangRepository : IRepository<ChucNang>
    {
        // Phương thức quản lý chức năng
        Task<List<ChucNang>> GetAllChucNangAsync();
        Task<ChucNang> PostChucNangAsync(string TenChucNang);
        Task PutChucNangAsync(ChucNang chucNang, int id);
        Task DeleteChucNangAsync(int id);
    }
}
