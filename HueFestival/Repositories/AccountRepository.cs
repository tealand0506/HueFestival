using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Runtime.CompilerServices;

namespace HueFestival.Repositories
{       
    public class AccountRepository : Repository<Account> , IAccountRepository
    {
        private readonly HueFestival_DbContext _context;
        public AccountRepository(HueFestival_DbContext context) : base(context)
        {
            
        }
        public async Task<List<Account>> GetAllAsync()
        {
            return await GetAllAsync();
        }
        public async Task<Account?> GetAccountLoginAsync(AccountDTO Account)
        {
            List<Account> accounts = await GetAllAsync();
            return accounts.FirstOrDefault(x => x.TenDN == Account.TenDN && x.Password == Account.Password);

        }
        public async Task<Account?> GetAccountByIDAsync(int id)
        {
            List<Account> accounts = await GetAllAsync();
            return accounts.FirstOrDefault(x => x.IdAcc == id);
        }
        public async Task DeleteAccountAsync(Account account)
        {
            await DeleteAsync(account);
        }

        public async Task<Account> AddAccountAsync(AccountDTO accountDTO)
        {
            Account newAccount = new Account
            {
                TenDN = accountDTO.TenDN,
                HoTen = accountDTO.HoTen,
                Email = accountDTO.Email,
                Password = accountDTO.Password,
                SDT = accountDTO.SDT,
                IdChucVu = accountDTO.IdChucVu
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            return newAccount;
        }

        public async Task<bool> CheckUsernameAsync(string username)
        {
            
            Account account = await _context.Accounts.FirstOrDefaultAsync(a => a.TenDN == username);

            
            if (account != null)
            {
                return true;
            }

            
            return false;
        }
        public async Task UpdateChucVuAsync(Account account, int IdChucVu)
        {
            
            ChucVu chucVu = await _context.ChucVus.FirstOrDefaultAsync(cv => cv.IdChucVu == IdChucVu);

            
            if (chucVu != null)
            {
                account.IdChucVu = chucVu.IdChucVu;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Chức vụ không tồn tại");
            }
        }

    }
}
