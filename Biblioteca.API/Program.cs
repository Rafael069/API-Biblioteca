using Biblioteca.Application.Commands.Livros.CreateLivro;
using Biblioteca.Core.Interfaces;
using Biblioteca.Infrastructure.Persistence;
using Biblioteca.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.


            var connectionString = builder.Configuration.GetConnectionString("BibliotecaCs");
            builder.Services.AddDbContext<BibliotecaDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ILivroRepository,LivroRepository>();
            builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            builder.Services.AddControllers();

            builder.Services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining(typeof(CreateLivroCommand)));

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
