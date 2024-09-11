using Biblioteca.Core.Interfaces;
using MediatR;

namespace Biblioteca.Application.Commands.Livros.DeleteLivro
{
    public class DeleteLivroCommandHandler : IRequestHandler<DeleteLivroCommand, Unit>
    {
        private readonly ILivroRepository _livroRepository;
        public DeleteLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }


        public async Task<Unit> Handle(DeleteLivroCommand request, CancellationToken cancellationToken)
        {

            var livro = await _livroRepository.GetByIdLivroAsync(request.Id);

            // Marca o livro como cancelado (exclusão lógica)
            livro.Cancel();

            await _livroRepository.UpdateLivroAsync(livro);

            return Unit.Value;
        }
    }
}
