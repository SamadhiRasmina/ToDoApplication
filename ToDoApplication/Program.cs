using Microsoft.EntityFrameworkCore;
using ToDoApplication.ApplicationCore.Common.Infastructure;
using ToDoApplication.ApplicationCore.Common.Interfaces;
using ToDoApplication.ApplicationCore.Common.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the in-memory database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ToDoDb")); // Replace "YourDbContext" with your actual DbContext class.

builder.Services.AddScoped<IToDoService, ToDoService>();

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
