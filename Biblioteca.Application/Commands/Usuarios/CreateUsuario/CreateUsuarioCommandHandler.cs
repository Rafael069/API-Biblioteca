using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Commands.Usuarios.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {

            var usuario = new Usuario(request.Nome, request.Email);
            await _usuarioRepository.AddUsuarioAsync(usuario);

            return usuario.Id;
        }
    }
}
