using MediatR;
using Biblioteca.Core.Interfaces;

namespace Biblioteca.Application.Commands.Usuarios.UpdateUsuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Unit>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            
            var usuario = await _usuarioRepository.GetByIdUsuarioAsync(request.Id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }


            // Atualizar as propriedades do usuário

            usuario.Update(request.Nome, request.Email);
            await _usuarioRepository.UpdateUsuarioAsync(usuario);

            return Unit.Value;
        }
    }
}
