
namespace Biblioteca.Core.Exceptions
{
    public  class UsuarioNaoEncontradoException : Exception
    {
        public UsuarioNaoEncontradoException(int id)
       : base($"Usuário  com ID {id} não encontrado.")
        {
        }
    }
}
