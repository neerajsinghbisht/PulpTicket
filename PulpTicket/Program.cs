
using Microsoft.Data.SqlClient;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.Services;
using PulpTicket.Domain.Repositories;
using PulpTicket.Infrastructure.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IUserRepository, UserRepository>(); // Ensure UserRepository is registered
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.UserProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.AddressProfile));


builder.Services.AddScoped<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DbConnection");
    return new SqlConnection(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PulpTicket API V1");
        c.RoutePrefix = string.Empty; // Swagger UI at the app's root
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();