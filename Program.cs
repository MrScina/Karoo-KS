using Karoo_KS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
var app = builder.Build();
//app.UseCors((g) => g.AllowAnyOrigin());
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("./v1/swagger.json", "Karoo-KS V1"); //originally "./swagger/v1/swagger.json"
//});
builder.Services.AddCors();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
   
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
