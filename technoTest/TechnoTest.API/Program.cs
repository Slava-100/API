using TechnoTest.API.MapperProfiles;
using TechnoTest.BLL;
using TechnoTest.BLL.Interfaces;
using TechnoTest.BLL.MapperProfiles;
using TechnoTest.DAL;
using TechnoTest.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<Context>();

builder.Services.AddAutoMapper(typeof(MapperApiUserProfile), typeof(MapperBLLUserProfile));

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
