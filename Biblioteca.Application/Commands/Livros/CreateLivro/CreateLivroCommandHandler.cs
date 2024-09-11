using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces;
using MediatR;

namespace Biblioteca.Application.Commands.Livros.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, int>
    {
        private readonly ILivroRepository _livroRepository;

        public CreateLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<int> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);

            await _livroRepository.AddLivroAsync(livro);

            return livro.Id;
        }
    }
}
