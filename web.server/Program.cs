using Microsoft.EntityFrameworkCore;
using web.server.service;
using web.server;
using web.server.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//����EFCore
builder.Services.AddDbContext<MyDbcontext>(opt =>
{
    string? connectionString = builder.Configuration.GetConnectionString("MySQLConnection");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    opt.UseMySql(connectionString, serverVersion);
});
//���ÿ������
builder.Services.AddCors(option => option.AddPolicy("cors", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
//ע�����
builder.Services.AddScoped<IBlogService, BlogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//���ÿ���
app.UseCors("cors");

//����API
app.MapPost("add", (TBlog blog, IBlogService blogService) => blogService.AddAsync(blog));
app.MapGet("getall", (IBlogService blogService) => blogService.GetAllAsync());
app.MapGet("get", (string id, IBlogService blogService) => blogService.GetAsync(int.Parse(id)));
app.MapDelete("delete", (string password, int id, IBlogService blogService) => blogService.DeleteAsync(id, password));
app.MapPost("update", (string password, TBlog blog, IBlogService blogService) => blogService.UpdateAsync(blog, password));

//������Ŀ
app.Run();
