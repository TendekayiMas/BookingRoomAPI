using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RoomsBookingAPI.Data;
using RoomsBookingAPI.Data.Repositories;
using RoomsBookingAPI.Models;
using RoomsBookingAPI.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RoomsDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICrudRepository<TblRooms, int>, RoomRepository>();
builder.Services.AddScoped<ICrudServices<TblRooms, int>, RoomServices>();
builder.Services.AddScoped<ICrudRepository<Users, int>, UserRepository>();
builder.Services.AddScoped<ICrudServices<Users, int>, UserServices>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});





builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.


app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

