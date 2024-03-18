// 1 Using to work with EF
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using rememberCs;
using rememberCs.DataAccess;
using rememberCs.Services;

var builder = WebApplication.CreateBuilder(args);

// 2 Conecction with DB

const string ConnectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(ConnectionName);

// 3. Add Context
builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(connectionString));

// 7. Add Service of JWT Auth

builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();

// Add Services Custom

builder.Services.AddScoped<IStudentService, StudentService>();

// Todo: add rest service

// 8. Add Auth Policyty
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", policy => policy.RequireClaim("UserOnly","User1"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 9.Config to take care Auth jwt
builder.Services.AddSwaggerGen(options =>
{
    // Define Security
    options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
    {
        Name= "Authorization",
        Type= SecuritySchemeType.Http,
        Scheme= "Bearer",
        BearerFormat = "JWT",
        In= ParameterLocation.Header,
        Description= "JWT Authorization Header using beare Scheme"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type= ReferenceType.SecurityScheme,
                    Id= "Bearer"
                }
            },
            new string[]{ } 
        }
    });

});

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
