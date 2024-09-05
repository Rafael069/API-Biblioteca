using Biblioteca.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.Livros.GetByIdLivro
{
    public class GetByIdLivroQuery : IRequest<LivroDetailsViewModel>
    {
        public GetByIdLivroQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
