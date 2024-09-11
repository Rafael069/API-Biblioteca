using Biblioteca.Application.ViewModels;
using MediatR;

namespace Biblioteca.Application.Queries.Usuarios.GetByIdUsuario
{
    public class GetByIdUsuarioQuery : IRequest<UsuarioDetailsViewModel>
    {
        public GetByIdUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
