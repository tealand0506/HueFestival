using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface ICheckInRepository : IRepository<Check_in>
    {
        Task<List<Check_in>> danhSachCheckIn();
        Task<Check_in> Check_In(string QRcode);
    }
}
