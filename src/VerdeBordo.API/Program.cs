using Microsoft.EntityFrameworkCore;
using VerdeBordo.API.Services;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.Infra.Persistence;
using VerdeBordo.Infra.Persistence.Repository;
using VerdeBordo.Infra.Persistence.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("VerdeBordoCs");
builder.Services.AddDbContext<VerdeBordoContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("VerdeBordo.Infra")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();
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
