using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface IHoTroRepository : IRepository<HoTro>
    {
        Task<List<HoTro>> DanhSachHoTro();

        Task<HoTro?> XuatHoTroTheoID(int id);

        Task<HoTro> ThemHoTro(HoTroDTO ht);

        Task XoaHoTro(HoTro ht);

        Task SuaHoTro(HoTroDTO htCanSua, HoTro htMoi);
    }
}
