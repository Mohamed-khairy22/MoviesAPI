
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Repsitories;

namespace MoviesAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IGenreRepo,GenreRepo>();
            builder.Services.AddScoped<IMovieRepo, MovieRepo>();
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddDbContext<MovieDbContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(c =>c.AllowAnyHeader().AllowAnyMethod().WithOrigins("googel.com"));
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
