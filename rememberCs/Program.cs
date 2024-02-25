// 1 Using to work with EF
using Microsoft.EntityFrameworkCore;
using rememberCs.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// 2 Conecction with DB

const string ConnectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(ConnectionName);

// 3. Add Context
builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.

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
