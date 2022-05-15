using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VerdeBordo.API.Services;
using VerdeBordo.API.Services.Interfaces;
using VerdeBordo.Infra.Persistence;
using VerdeBordo.Infra.Persistence.Repositories;
using VerdeBordo.Infra.Persistence.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("VerdeBordoCs");
builder.Services.AddDbContext<VerdeBordoContext>(o => o.UseSqlServer(connectionString, b => b.MigrationsAssembly("VerdeBordo.Infra")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "VerdeBordo.API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Pablo Souza",
            Email = "oliveirasouzapablo@gmail.com",
            Url = new Uri("https://github.com/pabloosouza")
        }
    });
     
    var xmlPath = Path.Combine(AppContext.BaseDirectory, "VerdeBordo.API.xml");
    o.IncludeXmlComments(xmlPath);
});

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
