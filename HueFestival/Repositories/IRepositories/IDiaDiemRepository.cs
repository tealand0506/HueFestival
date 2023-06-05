using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IDiaDiemRepository : IRepository<DiaDiem>
    {
        Task<List<DiaDiem>> GetAllDiaDiemAsync();
        Task<DiaDiem> PostDiaDiemAsync(DiaDiem DD);
        Task PutDiaDiemAsync(DiaDiem DD_CanDoi, DiaDiem DD_Moi);
        Task DeleteDiaDiemAsync(DiaDiem DD);
        Task<DiaDiem?> GetDiaDiemById(int Id); 
    }
}
