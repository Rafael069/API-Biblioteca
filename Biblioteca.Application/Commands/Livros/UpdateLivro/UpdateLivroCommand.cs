using MediatR;

namespace Biblioteca.Application.Commands.Livros.UpdateLivro
{
    public class UpdateLivroCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}
