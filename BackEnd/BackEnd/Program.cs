using BackEnd.Data;
using BackEnd.Repositories;
using BackEnd.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                         // policy.WithHeaders("Content-Type");
                         policy.AllowAnyHeader();   
                         policy.AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMemberService, MemberService>();

//IzboriDb
builder.Services.AddDbContext<IzboriDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConectionString"));
});

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowedOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
