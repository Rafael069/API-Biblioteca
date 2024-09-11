using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Commands.Usuarios.DeleteUsuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Unit>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public DeleteUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Unit> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            await _usuarioRepository.DeleteUsuarioAsync(request.Id);

            return Unit.Value;
        }
    }
}
