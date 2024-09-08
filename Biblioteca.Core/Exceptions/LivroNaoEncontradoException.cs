
namespace Biblioteca.Core.Exceptions
{
    public  class LivroNaoEncontradoException : Exception
    {
        public LivroNaoEncontradoException(int id)
       : base($"Livro com ID {id} não encontrado.")
        {
        }
    }
}
