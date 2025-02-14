using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Bussiness.Repositories;
using MiCarrito.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson((options) =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
});

var connectionString = builder.Configuration.GetConnectionString("Database");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Missing database connection string.");
}

// Add services to the container.
builder.Services.AddScoped<IArticulos, ArticulosRepository>();
builder.Services.AddScoped<IArticuloTienda, ArticuloTiendaRepository>();
builder.Services.AddScoped<IClienteArticulo, ClienteArticuloRepository>();
builder.Services.AddScoped<IClientes, ClientesRepository>();
builder.Services.AddScoped<ITienda, TiendaRepository>();


builder.Services.AddControllers();

builder.Services.AddDbContext<CarritoDbContext>((opts) =>
{
    opts.UseSqlServer(connectionString, opts =>
    {
        opts.MigrationsAssembly("MiCarrito.Data");
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowCredentials();
            builder.WithOrigins("http://localhost:4200");
        });
});

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
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
