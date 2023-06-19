using HueFestival.DataTransferObject;
using HueFestival.Models;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Repositories.IRepositories
{
    public interface IChucVuRepository : IRepository<ChucVu>
    {
        // Phương thức quản lý chức vụ
        Task<List<ChucVu>> GetAllChucVuAsync();// lấy danh sách tất cả chức vụ
        Task<ChucVu?> GetByIdChecVuAsynnc(int id);
        Task<ChucVu> PostChucVuAsync(ChucVuDTO chucVu);// thêm chức vụ
        Task PutChucVuAsync(ChucVu chucVuCanSua, ChucVuDTO ChucVuMoi);//sửa chức vụ
        Task DeleteChucVuAsync(ChucVu chucVu);// xóa chức vụ

    }
}
