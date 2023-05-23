using Microsoft.EntityFrameworkCore.SqlServer;
using CarRentalManagement.CarService.DataAcessLayer.Data;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.PaymentService.DataAcLayer.Data;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Data;
using CarRentalManagement.RentalManagementService.BusinessLogicLayer.Services;
using CarRentalManagement.RentalManagementService.DataAccessLayer.Repositories;
using CarRentalManagement.CarService.BusinessLayer.Services;
using CarRentalManagement.CarService.DataAcessLayer.Repositories;
using CarRentalManagement.PaymentService.BusinessLoLayer.Services;
using CarRentalManagement.PaymentService.DataAcLayer.Repositories;
using CarRentalManagement.UserManagementService.DataALayer.Data;
using CarRentalManagement.UserManagementService.BusinessLLayer.Services;
using CarRentalManagement.UserManagementService.DataALayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CarDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Car")));
builder.Services.AddDbContext<RentalDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Rental")));
builder.Services.AddDbContext<PaymentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Payment")));
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("User")));

builder.Services.AddScoped<ICarS, CarS>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalCarService, RentalCarService>();
builder.Services.AddScoped<IRentalCarRepository, RentalCarRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IPaymentS, PaymentS>();
builder.Services.AddScoped<IPayementRepos, PaymentRepos>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserMRepos, UserMRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
