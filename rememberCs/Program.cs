// 1 Using to work with EF
using Microsoft.EntityFrameworkCore;
using rememberCs.DataAccess;
using rememberCs.Services;

var builder = WebApplication.CreateBuilder(args);

// 2 Conecction with DB

const string ConnectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(ConnectionName);

// 3. Add Context
builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(connectionString));

// 7. Add Service of JWT Auth

// Todo :
//builder.Services.addJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

// Add Services Custom

builder.Services.AddScoped<IStudentService, StudentService>();

// Todo: add rest service

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8. Todo:Config to take care Auth jwt
builder.Services.AddSwaggerGen();

// Add cors Config

builder.Services.AddCors(options => {
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
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

// Add cors in run time

app.UseCors("CorsPolicy");

app.Run();
