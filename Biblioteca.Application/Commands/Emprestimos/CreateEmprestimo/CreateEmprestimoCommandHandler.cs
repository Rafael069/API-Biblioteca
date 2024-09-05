using Biblioteca.Application.Commands.Emprestimos.CreateEmprestimo;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Emprestimos.CreateEmprestimo
{
    public class CreateEmprestimoCommandHandler : IRequestHandler<CreateEmprestimoCommand, int>
    {
        private readonly BibliotecaDbContext _dbContext;

        public CreateEmprestimoCommandHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var novoEmprestimo = new Emprestimo(
                request.UsuarioId,
                request.LivroId,
                request.DataEmprestimo,
                request.DataDevolucao
            );

            await _dbContext.Emprestimos.AddAsync(novoEmprestimo);
            await _dbContext.SaveChangesAsync();

            return novoEmprestimo.Id;
        }
    }
}
