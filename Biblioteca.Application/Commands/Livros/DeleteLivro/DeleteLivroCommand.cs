using MediatR;

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
