using Biblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Livros.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, Unit>
    {
        private readonly BibliotecaDbContext _dbContext;

        public UpdateLivroCommandHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = _dbContext.Livros.SingleOrDefault(l => l.Id == request.Id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            livro.Update(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
