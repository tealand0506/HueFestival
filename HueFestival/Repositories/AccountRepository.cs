using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
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
            _context = context;
        }
        public async Task<List<Account>> GetAllTaiKhoan()
        {
            return await _context.Accounts.Include(e => e.ChucVus).ToListAsync();
        }
        public async Task<Account> DangNhap(string Emaill, string Pass)
        {
            var TaiKhoan = _context.Accounts.FirstOrDefault(a => a.Email.ToLower() == Emaill.ToLower());
            if (TaiKhoan != null && Pass == TaiKhoan.Password)
            {
                return TaiKhoan;
            }
            return null;
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
            var newAccount = new Account    
            {
                TenDN = accountDTO.TenDN,
                HoTen = accountDTO.HoTen,
                Email = accountDTO.Email,
                Password = accountDTO.Password,
                SDT = accountDTO.SDT,
                IdChucVu = accountDTO.IdChucVu
            };

            
            await PostAsync(newAccount);

            return newAccount;
        }
        public async Task DoiMatKhau(Account acc, string MatKhau)
        {
            acc.Password = MatKhau;

            await PutAsync(acc);
        }
        public async Task<Account?> CheckUsernameAsync(string username)
        {

            Account account = await _context.Accounts.FirstOrDefaultAsync(a => a.TenDN == username);

            return account;
        }
        public async Task UpdateChucVuAsync(Account account)
        {
            
            var chucVu = await _context.ChucVus.FirstOrDefaultAsync(cv => cv.IdChucVu == account.IdChucVu);

            
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
