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
        Task<Token> TaoMaToken(Account account, ChucVu cv);
        Task DeleteAccountAsync(Account account);

        Task<Account> PostAccountAsync(string sdt, string email, int IdChucVu);

        Task<Account> CheckUsernameAsync(string username);
        Task<Account> DangNhap(AccountDTO dn);
        //Task UpdateChucVuAsync(Account account);
       

    }
}
                            