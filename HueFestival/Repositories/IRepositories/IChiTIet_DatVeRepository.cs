using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IChiTiet_DatVeRepository : IRepository<ChiTiet_DatVe>
    {
        Task<List<ChiTiet_DatVe>> DSachDatVe();
        Task<object?> DatVe(ChiTiet_DatVeDTO datVeDTO);
    }
}
