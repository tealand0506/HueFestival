using HueFestival.DataTransferObject;
using HueFestival.Models;

namespace HueFestival.Repositories.IRepositories
{
    public interface INguoiDungRepository : IRepository<NguoiDung>
    {
        //danh sach nguoi dung theo chuc vu
        Task<List<NguoiDung>> GetNguoiDungByChucVuAsync ();
        
        //nguoi dung ID
        Task<NguoiDung?> GetNguoiDungbyIdAsync(int id);

        //tao nguoi dung - acc
        Task<NguoiDung> PostNguoiDungAsync(NguoiDungDTO ndDTO, int idAcc);

        //xoa sua
    }
}