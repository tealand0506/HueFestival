using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories.IRepositories;
using HueFestival.Repository.IRepository;

namespace HueFestival.Repositories.IRepositories
{
    public interface IQuyenHanhRepository : IRepository<QuyenHanh>
    {
        // Phương thức quản lý quyền hanh của chức vụ
        Task<List<Tuple<string, string>>> GetAllQuyenHanhWithNameAsync();
        Task<QuyenHanh> PostQuyenHanhAsync(int IsChucNang, int idChucVu);
        Task PutQuyenHanhAsync(QuyenHanh quyenHanh, int id);
        Task DeleteQuyenHanhAsync(int id);
    }
}
