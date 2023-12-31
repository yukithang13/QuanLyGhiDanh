﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PhanMemGhiDanh.Data;
using QuanLyGhiDanh.Helpers;
using QuanLyGhiDanh.Interface;
using QuanLyGhiDanh.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<GhiDanhDbContext>().AddDefaultTokenProviders()
    .AddRoleManager<RoleManager<IdentityRole>>(); ;


builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IGiangVienService, GiangVienService>();
builder.Services.AddScoped<IHocVienService, HocVienService>();
builder.Services.AddScoped<IKhoaHocService, KhoaHocService>();
builder.Services.AddScoped<ILopHocService, LopHocService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<INhomBoMonService, NhomBoMonService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddDbContext<GhiDanhDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GhiDanh"));
});
//--------------------------------------------------------------------------------------------------

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/SignIn"; // Đường dẫn đến trang đăng nhập
    options.AccessDeniedPath = "/Account/AccessDenied"; // Đường dẫn khi truy cập bị từ chối
});

//--------------------------------------------------------------------------------------------------
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireUserRole", policy =>
        policy.RequireRole("User"));

    options.AddPolicy("RequireTeacherRole", policy =>
        policy.RequireRole("Teacher"));

    options.AddPolicy("RequireAdminRole", policy =>
        policy.RequireRole("AdminRole"));

    // Thêm các ủy quyền khác ở đây....
});

//--------------------------------------------------------------------------------------------------
builder.Services.AddSwaggerGen(sw =>
{
    sw.SwaggerDoc("v1", new OpenApiInfo { Title = "JWT", Version = "v1" });
    sw.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    sw.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }

    });

}); // Bearer [Token]



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };

});


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();