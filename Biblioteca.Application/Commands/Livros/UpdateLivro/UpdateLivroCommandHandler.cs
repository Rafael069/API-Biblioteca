using Biblioteca.Core.Interfaces;
using MediatR;

namespace Biblioteca.Application.Commands.Livros.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, Unit>
    {

        private readonly ILivroRepository _livroRepository;
        public UpdateLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<Unit> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {

            // Recupera o livro pelo ID usando o repositório
            var livro = await _livroRepository.GetByIdLivroAsync(request.Id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            // Atualiza as propriedades do livro
            livro.Update(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);

            // Atualiza o livro no repositório
            await _livroRepository.UpdateLivroAsync(livro);

            return Unit.Value;
        }
    }
}
