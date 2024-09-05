using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Livros.DeleteLivro
{
    public class DeleteLivroCommand : IRequest<Unit>
    {
        public DeleteLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
