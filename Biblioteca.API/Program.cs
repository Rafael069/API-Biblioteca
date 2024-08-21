using Biblioteca.Application.Services;
using Biblioteca.Application.Services.Implementations;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            //builder.Services.AddSingleton<BibliotecaDbContext>();
            var connectionString = builder.Configuration.GetConnectionString("BibliotecaCs");
            builder.Services.AddDbContext<BibliotecaDbContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddScoped<IEmprestimoService,EmprestimoService>();
            builder.Services.AddScoped<ILivroService, LivroService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddControllers();
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
        }
    }
}
