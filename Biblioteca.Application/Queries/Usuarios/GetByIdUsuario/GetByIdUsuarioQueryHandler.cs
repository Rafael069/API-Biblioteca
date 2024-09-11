using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Exceptions;
using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Queries.Usuarios.GetByIdUsuario
{

    public class GetByIdUsuarioQueryHandler : IRequestHandler<GetByIdUsuarioQuery, UsuarioDetailsViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public GetByIdUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDetailsViewModel> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdUsuarioAsync(request.Id);


            if (usuario == null)
            {
                throw new UsuarioNaoEncontradoException(request.Id);
            }

            var usuarioDetailsViewModel = new UsuarioDetailsViewModel(
                usuario.Id,
                usuario.Nome,
                usuario.Email
                );

            return usuarioDetailsViewModel;
        }
    }
}
