using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using HueFestival.Repository;
using Microsoft.EntityFrameworkCore;

namespace HueFestival
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HueFestival_DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
            //builder.Services.AddAuthentication(...)
            builder.Services.AddAutoMapper(typeof(Program));


            /*
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOrStaffOrManager", policy => policy.RequireRole(RoleAssignment.ADMIN, RoleAssignment.MANAGER, RoleAssignment.STAFF));
                options.AddPolicy("AdminOrManager", policy => policy.RequireRole(RoleAssignment.ADMIN, RoleAssignment.MANAGER));
                options.AddPolicy("ManagerOrStaff", policy => policy.RequireRole(RoleAssignment.STAFF, RoleAssignment.MANAGER));
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole(RoleAssignment.ADMIN));
                options.AddPolicy("ManagerPolicy", policy => policy.RequireRole(RoleAssignment.MANAGER));
                options.AddPolicy("StaffPolicy", policy => policy.RequireRole(RoleAssignment.STAFF));
                options.AddPolicy("ReporterPolicy", policy => policy.RequireRole(RoleAssignment.REPORTER));
            });
            */

            builder.Services.AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IQuyenHanhRepository, QuyenHanhRepository>()
                .AddScoped<IChucNangRepository, ChucNangRepository>()
                .AddScoped<IChucVuRepository, ChucVuRepository>();
            /*
                .AddScoped<ICheckinRepository, ICheckinRepository>()
                .AddScoped<IChiTiet_CTrRepository, ChiTiet_CTrRepository>()
                .AddScoped<IChiTiet_DatVeRepository, ChiTiet_DatVeRepository>()
                .AddScoped<IChuongTrinhRepository, ChuongTrinhRepository>()
                .AddScoped<IDiaDiemRepository, DiaDiemRepository>()
                .AddScoped<IDoanNTRepository, DoanNTRepository>()
                .AddScoped<IHinhAnh_CTrRepository, HinhAnh_CTrRepository>()
                .AddScoped<IHoTroRepository, HoTroRepository>()
                .AddScoped<ILoai_DiaDiemRepository, Loai_DiaDiemRepository>()
                .AddScoped<ILoai_VeRepository, Loai_VeRepository>()
                .AddScoped<INhomCTrRepository, NhomCTrRepository>()
                .AddScoped<IThongTin_VeRepository, ThongTin_VeRepository>()
                .AddScoped<ITinTucRepository, TinTucRepository>();
                */

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}