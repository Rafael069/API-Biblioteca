using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Exceptions;
using Biblioteca.Core.Interfaces;
using MediatR;

namespace Biblioteca.Application.Queries.Livros.GetByIdLivro
{
    public class GetByIdLivroQueryHandler : IRequestHandler<GetByIdLivroQuery, LivroDetailsViewModel>
    {
        private readonly ILivroRepository _livroRepository;

        public GetByIdLivroQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }


        public async Task<LivroDetailsViewModel> Handle(GetByIdLivroQuery request, CancellationToken cancellationToken)
        {

            var livros = await _livroRepository.GetByIdLivroAsync(request.Id);


            if (livros == null)
            {
                throw new LivroNaoEncontradoException(request.Id);
            }


            var livroDetailsViewModel = new LivroDetailsViewModel(
                livros.Id,
                livros.Titulo,
                livros.Autor,
                livros.ISBN,
                livros.AnoPublicacao
                );

            return livroDetailsViewModel;
        }
    }
}
