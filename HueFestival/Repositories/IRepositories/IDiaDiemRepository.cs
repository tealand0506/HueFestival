using HueFestival.Models;
using HueFestival.DataTransferObject;

namespace HueFestival.Repositories.IRepositories
{
    public interface IDiaDiemRepository : IRepository<DiaDiem>
    {
        Task<List<DiaDiem>> GetAllDiaDiemAsync();
        Task<DiaDiem> PostDiaDiemAsync(DiaDiemDTO diaDiemDTO);
        Task PutDiaDiemAsync(DiaDiem DD_CanDoi, DiaDiemDTO DD_Moi);
        Task DeleteDiaDiemAsync(DiaDiem DD);
        Task<DiaDiem?> GetDiaDiemById(int Id); 
    }
}
