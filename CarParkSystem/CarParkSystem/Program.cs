using CarParkSystem.Interfaces;
using CarParkSystem.MappingConfigurations;
using CarParkSystem.Persistence;
using CarParkSystem.Persistence.Interfaces;
using CarParkSystem.Persistence.Models;
using CarParkSystem.Persistence.Records;
using CarParkSystem.Persistence.Repositories;
using CarParkSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CarParkDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
}).AddEntityFrameworkStores<CarParkDbContext>();
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IParkingHouseRepository, ParkingHouseRepository>();
builder.Services.AddScoped<ISlotRepository, SlotRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IParkingHouseService,ParkingHouseService>();
builder.Services.AddScoped<ILevelService,LevelService>();
builder.Services.AddScoped<ISlotService,SlotService>();
builder.Services.AddScoped<IReservationService,ReservationService>();

builder.Services.AddScoped<ICustomMapper, CustomMapper>();

var app = builder.Build();
var key = Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"].ToString());

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<CarParkDbContext>();

    // Here is the migration executed 
    try
    {
       dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine("The database is exist.");
    }
}

app.UseCors(
    options => options.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
);

app.UseCors(
    options => options.WithOrigins("http://localhost:7154")
        .AllowAnyHeader()
        .AllowAnyMethod()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
