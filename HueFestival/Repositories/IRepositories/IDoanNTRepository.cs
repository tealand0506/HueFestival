using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IDoanNTRepository : IRepository<DoanNT>
    {
        Task<List<DoanNT>> GetAllDoanNT();
        Task<DoanNT?> GetByIdDoanNT(int Id);
        Task<DoanNT> PostDoanNT(string TenDoan);
        Task PutDoanNT(DoanNT doanCanSua, DoanNT doanMoi);
        Task DeleteDoanNT(DoanNT doan);
    }
}
