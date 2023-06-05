using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface ILoai_DiaDiemRepository : IRepository<Loai_DiaDiem>
    {
        Task<List<Loai_DiaDiem>> GetAllLoai_DiaDiemAsync();
        Task<Loai_DiaDiem> PostLoai_DiaDiemAsync(Loai_DiaDiem ldd);
        Task PutLoai_DiaDiemAsync(Loai_DiaDiem ldd_CanDoi, Loai_DiaDiem ldd_Moi);
        Task DeleteLoai_DiaDiemAsync(Loai_DiaDiem ldd);
        Task<Loai_DiaDiem> GetByIdLoai_DiaDiemAsync(int Id);

    }
}
