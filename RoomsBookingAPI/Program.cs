using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RoomsBookingAPI.Data;
using RoomsBookingAPI.Data.Repositories;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RoomsDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<TblRooms, int>, RoomRepository>();
builder.Services.AddScoped<ICrudServices<TblRooms, int>, RoomServices>();
builder.Services.AddScoped<ICrudRepository<Users, int>, UserRepository>();
builder.Services.AddScoped<ICrudServices<Users, int>, UserServices>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RoomsBookingRestAPI",
        Version =
    "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

