using Biblioteca.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
