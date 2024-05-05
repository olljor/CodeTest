using CodeTest.Core.Services;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string relativePath = builder.Configuration.GetConnectionString("DefaultConnection")!;
string localPath = AppDomain.CurrentDomain.BaseDirectory;
string dbPath = Path.Combine(localPath, relativePath);

Batteries.Init();
builder.Services.AddScoped<IDbConnection>(c => new SqliteConnection($"Data Source={dbPath}"));

builder.Services.AddTransient<ArticleService>();
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<OrderService>();
builder.Services.AddTransient<SetupService>();

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
