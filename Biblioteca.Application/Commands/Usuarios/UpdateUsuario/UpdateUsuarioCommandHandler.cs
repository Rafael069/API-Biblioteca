using Biblioteca.Infrastructure.Persistence;
//using DevFreela.Application.Commands.UpdateProject;
using Biblioteca.Application.Commands.Usuarios.UpdateUsuario;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Usuarios.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
    {
        private readonly BibliotecaDbContext _dbContext;

        public UpdateUsuarioCommandHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == request.Id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }

            // Atualizar as propriedades do usuário
            usuario.Update(request.Nome, request.Email);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
