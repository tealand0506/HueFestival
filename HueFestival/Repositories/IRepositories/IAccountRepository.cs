using HueFestival.DataTransferObject;
using HueFestival.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories.IRepositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<List<Account>> GetAllTaiKhoan();
        Task<Account?> GetAccountLoginAsync(AccountDTO Account);
        Task<Account?> GetAccountByIDAsync(int id);
        Task DoiMatKhau(Account acc, string MatKhau);
        Task DeleteAccountAsync(Account account);

        Task<Account> AddAccountAsync(AccountDTO accountDTO);

        Task<Account> CheckUsernameAsync(string username);
        Task<Account> DangNhap(string Emaill, string Pass);
        Task UpdateChucVuAsync(Account account);
       

    }
}
                            