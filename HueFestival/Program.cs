using HueFestival.Models;
using HueFestival.Repositories;
using HueFestival.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace HueFestival
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "HueFestival", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                IConfiguration configuration = builder.Configuration;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "")),
                    ClockSkew = TimeSpan.Zero
                };
            });
            builder.Services.AddDbContext<HueFestival_DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

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
                .AddScoped<IChucVuRepository, ChucVuRepository>()
                .AddScoped<IDiaDiemRepository, DiaDiemRepository>()
                .AddScoped<IChuongTrinhRepository, ChuongTrinhRepository>()
                .AddScoped<INhom_CTrRepository, Nhom_CTrRepository>()
                .AddScoped<ILoai_DiaDiemRepository, Loai_DiaDiemRepository>()
                .AddScoped<IHinhAnhCTRepository, HinhAnhCTRepository>()
                .AddScoped<IVeRepository, VeRepository>()
                .AddScoped<IKhachHangRepository, KhachHangRepository>()
                .AddScoped<IChiTiet_DatVeRepository, ChiTiet_DatVeRepository>()
                .AddScoped<ICheckInRepository, CheckInRepository>()
                .AddScoped<IHoTroRepository, HoTroRepository>()
                .AddScoped<IDoanNTRepository, DoanNTRepository>();
/*
                .AddScoped<IChiTiet_CTrRepository, ChiTiet_CTrRepository>()
               .AddScoped<ILoai_VeRepository, Loai_VeRepository>()
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

            app.UseAuthorization();


            app.UseDeveloperExceptionPage();

            app.MapControllers();

            app.Run();
        }
    }
}