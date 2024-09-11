using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Queries.Usuarios.GetAllUsuarios
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, List<UsuarioViewModel>>
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public GetAllUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioViewModel>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {

            var usuarios = await _usuarioRepository.GetAllUsuariosAsync();

            var usuariosViewModel = usuarios
               .Select(u => new UsuarioViewModel(u.Id, u.Nome, u.Email))
               .ToList();

            return usuariosViewModel;
        }
    }
}
