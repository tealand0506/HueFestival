using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IDoanNTRepository : IRepository<DoanNT>
    {
        Task<List<DoanNT>> GetAllDoanNTAsync();
        Task<DoanNT?> GetByIdDoanNTAsync(int Id);
        Task<DoanNT> PostDoanNTAsync(DoanNTDTO doanNtCanSua);
        Task PutDoanNTAsync(DoanNT doanCanSua, DoanNTDTO doanMoi);
        Task DeleteDoanNTAsync(DoanNT doan);
    }
}
