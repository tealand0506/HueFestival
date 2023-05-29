using HueFestival.Models;

namespace HueFestival.Repository.IRepository
{
    public interface IDiaDiemRepository : IRepository<DiaDiem>
    {
        public Task<List<DiaDiem>> GetAll_DiaDiem_Async();

    }
}
