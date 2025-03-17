using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiPessoas.Data;
using ApiPessoas;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiPessoasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiPessoasContext") ?? throw new InvalidOperationException("Connection string 'ApiPessoasContext' not found.")));

// Add services to the container.
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

app.MapPessoaModelEndpoints();

app.Run();

