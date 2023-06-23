using HueFestival.DataTransferObject;
using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace HueFestival.Repositories
{       
    public class AccountRepository : Repository<Account> , IAccountRepository
    {
        private readonly IConfiguration _configuration;
        private readonly HueFestival_DbContext _context;
        public AccountRepository(HueFestival_DbContext context, IConfiguration configuration) : base(context)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<Account>> GetAllTaiKhoan()
        {
            return await GetAllAsync();
        }
        
        public async Task<Account?> GetAccountByIDAsync(int id)
        {
            var accounts = await GetAllAsync();
            return accounts.FirstOrDefault(x => x.IdAcc == id);
        }   
        public async Task DeleteAccountAsync(Account account)
        {
            await DeleteAsync(account);
        }

        public async Task<Account> PostAccountAsync(string sdt, string email, int IdChucVu)// them nguoi dung tao tai khoan
        {
            var newAccount = new Account    
            {
                TenDN = email,
                Password = sdt,
            };
            
            await PostAsync(newAccount);
            return newAccount;
        }


        public async Task<Account> DangNhap(AccountDTO dn)
        {
            var TaiKhoan = _context.Accounts.FirstOrDefault(a => a.TenDN == dn.TenDN);
            if (TaiKhoan != null && dn.Password == TaiKhoan.Password)
            {
                return TaiKhoan;
            }
            return null;
        }
        public async Task<Token> TaoMaToken(Account account, ChucVu cv)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new Exception("Khóa JWT không hợp lệ");
            }
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);

            if (account == null || account.IdAcc == null)
            {
                throw new Exception("Tài khoản không hợp lệ");
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.IdAcc.ToString()),
                    new Claim(ClaimTypes.Role, cv?.TenChucVu ?? "")
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);
            var refreshToken = GetRefreshToken();

            var managerToken = new Token
            {
                MaToken = accessToken,
                IdJwt = refreshToken,
                IdAccount = account.IdAcc,
            };

            _context.Tokens.Add(managerToken);

            await _context.SaveChangesAsync();

            return managerToken;
        }

        private static string GetRefreshToken()
        {
            var random = new byte[32];
            using (var ran = RandomNumberGenerator.Create())
            {
                ran.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }
        public async Task<Account?> GetAccountLoginAsync(AccountDTO Account)
        {
            List<Account> accounts = await GetAllAsync();
            return accounts.FirstOrDefault(x => x.TenDN == Account.TenDN && x.Password == Account.Password);

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
        // public async Task UpdateChucVuAsync(Account account)
        // {
            
        //     var chucVu = await _context.ChucVus.FirstOrDefaultAsync(cv => cv.IdChucVu == account.IdChucVu);

            
        //     if (chucVu != null)
        //     {
        //         account.IdChucVu = chucVu.IdChucVu;
        //         await _context.SaveChangesAsync();
        //     }
        //     else
        //     {
        //         throw new Exception("Chức vụ không tồn tại");
        //     }
        // }
    }
}
