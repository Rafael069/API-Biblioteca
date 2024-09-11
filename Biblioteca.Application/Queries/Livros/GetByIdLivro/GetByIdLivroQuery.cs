using Biblioteca.Application.ViewModels;
using MediatR;


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
