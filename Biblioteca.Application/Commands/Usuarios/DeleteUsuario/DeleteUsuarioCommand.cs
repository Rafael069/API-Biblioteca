using MediatR;

namespace Biblioteca.Application.Commands.Usuarios.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<Unit>
    {
        public DeleteUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
