using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Queries.Livros.GetAllLivros
{
    public class GetAllLivrosQueryHandler : IRequestHandler<GetAllLivrosQuery, List<LivroViewModel>>
    {

        private readonly ILivroRepository _livroRepository;


        public GetAllLivrosQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }


        public async Task<List<LivroViewModel>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllLivrosAsync();

            var livrosViewModel = livros
                .Select(l => new LivroViewModel(l.Id, l.Titulo, l.Autor))
                .ToList();

            return livrosViewModel;
        }
    }
}
