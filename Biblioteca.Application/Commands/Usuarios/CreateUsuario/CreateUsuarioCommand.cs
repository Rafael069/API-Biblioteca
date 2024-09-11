using MediatR;

namespace Biblioteca.Application.Commands.Usuarios.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
