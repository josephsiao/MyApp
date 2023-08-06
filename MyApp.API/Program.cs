using Microsoft.Extensions.Configuration;
using MyApp.Application;
using MyApp.Persistence;

var builder = WebApplication.CreateBuilder(args);
// 設置 IConfiguration，讀取 appsettings.json 文件
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();

// 註冊 MyApp.Application 專案中的服務
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

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
