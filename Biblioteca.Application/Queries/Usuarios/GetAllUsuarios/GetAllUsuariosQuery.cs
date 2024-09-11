using Biblioteca.Application.ViewModels;
using MediatR;

namespace Biblioteca.Application.Queries.Usuarios.GetAllUsuarios
{
    public class GetAllUsuariosQuery : IRequest<List<UsuarioViewModel>>
    {
    }
}
