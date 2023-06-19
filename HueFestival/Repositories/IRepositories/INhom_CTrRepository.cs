using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface INhom_CTrRepository : IRepository<Nhom_CTr>
    {
        Task<List<Nhom_CTr>> GetAllNhom_CTrRepository();
        Task<Nhom_CTr?> GetByIdNhom_CTrRepository(int Id);
        Task<Nhom_CTr> PostNhom_CTrRepository(Nhom_CTrDTO Nhom);
        Task PutNhom_CTrRepository(Nhom_CTr nhomCanDoi, Nhom_CTrDTO nhomMoi);
        Task DeleteNhom_CTrRepository(Nhom_CTr nhom);
    }
}
