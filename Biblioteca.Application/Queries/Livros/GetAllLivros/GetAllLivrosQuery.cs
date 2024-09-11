using Biblioteca.Application.ViewModels;
using MediatR;

namespace Biblioteca.Application.Queries.Livros.GetAllLivros
{
    public class GetAllLivrosQuery : IRequest<List<LivroViewModel>>
    {
    }
}
