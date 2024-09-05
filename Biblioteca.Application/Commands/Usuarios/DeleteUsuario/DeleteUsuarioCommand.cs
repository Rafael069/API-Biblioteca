using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
