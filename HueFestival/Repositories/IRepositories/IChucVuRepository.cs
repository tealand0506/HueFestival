using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Repositories.IRepositories
{
    public interface IChucVuRepository : IRepository<ChucVu>
    {
        // Phương thức quản lý chức vụ
        Task<List<ChucVu>> GetAllChucVuAsync();// lấy danh sách tất cả chức vụ
        Task<ChucVu>  PostChucVuAsync(string TenChucVu);// thêm chức vụ
        Task PutChucVuAsync(ChucVu chucVu, int id);//sửa chức vụ
        Task DeleteChucVuAsync(int id);// xóa chức vụ

    }
}
