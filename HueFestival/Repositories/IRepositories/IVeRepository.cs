using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IVeRepository : IRepository<ThongTin_Ve>
    {
        Task<List<ThongTin_Ve>> DanhSachThongTinVe();
        Task<ThongTin_Ve?> GetByIdThongTinVe(int id);
        Task<ThongTin_Ve> PostThongTinVe(ThongTin_VeDTO VeDTO);
        Task PutThongTinVe(ThongTin_VeDTO VeCanSua, ThongTin_VeDTO VeMoi);
        Task DeleteThongTinVe(ThongTin_VeDTO VeCanXoa);
    }
}
