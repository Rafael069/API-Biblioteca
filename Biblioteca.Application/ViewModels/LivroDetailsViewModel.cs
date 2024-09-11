
namespace Biblioteca.Application.ViewModels
{
    public class LivroDetailsViewModel
    {
        public LivroDetailsViewModel(int id, string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
    }
}
