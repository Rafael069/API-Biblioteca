using Biblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Livros.DeleteLivro
{
    public class DeleteLivroCommandHandler : IRequestHandler<DeleteLivroCommand, Unit>
    {

        private readonly BibliotecaDbContext _dbContext;

        public DeleteLivroCommandHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Unit> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = _dbContext.Livros.SingleOrDefault(l => l.Id == request.Id);

            livro.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
