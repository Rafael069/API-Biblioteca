using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Livros.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, int>
    {

        private readonly BibliotecaDbContext _dbContext;

        public CreateLivroCommandHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();

            return livro.Id;
        }
    }
}
