using MediatR;

namespace Biblioteca.Application.Commands.Usuarios.UpdateUsuario
{
    public class UpdateUsuarioCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
