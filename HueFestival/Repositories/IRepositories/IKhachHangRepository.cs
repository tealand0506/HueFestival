using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IKhachHangRepository : IRepository<KhachHang>
    {
        Task<List<KhachHang>> GetAllKhachHangAsync();
        Task<KhachHang?> GetByIdKhachHangAsync(int id);
        Task<KhachHang> PostKhachHangAsync(KhachHangDTO khDTO);
        Task PutKhachHangAsync(KhachHang khCanSua, KhachHangDTO khMoi);
        Task DeleteKhachHangAsync(KhachHang khDTO);
    }
}
