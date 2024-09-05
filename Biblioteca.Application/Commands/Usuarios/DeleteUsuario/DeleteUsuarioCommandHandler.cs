//using Biblioteca.Application.Commands.DeleteLivro;
using Biblioteca.Application.Commands.Usuarios.DeleteUsuario;
using Biblioteca.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Usuarios.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
    {
        private readonly BibliotecaDbContext _dbContext;

        public DeleteUsuarioCommandHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == request.Id);

            usuario.Cancel();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
