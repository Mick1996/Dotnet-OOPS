using Dependency_Injection.Data;
using Dependency_Injection.Interface;
using Dependency_Injection.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddTransient<IEmployee,EmployeeData>(); //Service registered for DI
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
