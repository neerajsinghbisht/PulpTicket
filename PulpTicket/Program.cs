
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using PulpTicket.Application.Interfaces;
using PulpTicket.Application.Services;
using PulpTicket.Domain.Repositories;
using PulpTicket.Infrastructure.Repositories;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddScoped<IUserRepository, UserRepository>(); // Ensure UserRepository is registered
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieServices>();
builder.Services.AddScoped<IBookingServices, BookingService>();
builder.Services.AddScoped<IBookingRepository,BookingRepository>();
builder.Services.AddScoped<IShowRepository,ShowRepository>();
builder.Services.AddScoped<IShowServices, ShowServices>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityServices, CityServices>();
builder.Services.AddScoped<ICinemaHallRepository,CinemaHallRepository>();
builder.Services.AddScoped<ICinemaHallServices,CinemaHallService>();
builder.Services.AddScoped<IPaymentRepository,PaymentRepository>();
builder.Services.AddScoped<IPaymentServices,PaymentServices>();
builder.Services.AddScoped<IShowRepository,ShowRepository>();
builder.Services.AddScoped<IShowServices,ShowServices>();
builder.Services.AddScoped<IShowSeatRepository,ShowSeatRepository>();
builder.Services.AddScoped<IShowSeatServices,ShowSeatService>();




builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.UserProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.AddressProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.MovieProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.BookingProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.CityMapperProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.CinemaHallMappingProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.ShowProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.ShowSeatMapperProfile));
builder.Services.AddAutoMapper(typeof(PulpTicket.Application.Mappers.PaymentProfile));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

                });





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


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder.WithOrigins("https://localhost:5174/") // Allow your React app origin
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()); // If credentials (cookies, auth headers) are needed
});



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
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();