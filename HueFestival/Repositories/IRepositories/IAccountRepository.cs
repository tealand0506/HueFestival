using HueFestival.DataTransferObject;
using HueFestival.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFestival.Repositories.IRepositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> GetAccountLoginAsync(AccountDTO Account);
        Task<Account?> GetAccountByIDAsync(int id);
        Task DeleteAccountAsync(Account account);

        Task<Account> AddAccountAsync(AccountDTO accountDTO);

        Task<bool> CheckUsernameAsync(string username);
        Task UpdateChucVuAsync(Account account, int IdChucVu);
       

    }
}
                            