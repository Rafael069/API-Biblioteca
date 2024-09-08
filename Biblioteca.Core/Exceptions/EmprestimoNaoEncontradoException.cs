
namespace Biblioteca.Core.Exceptions
{
    public  class EmprestimoNaoEncontradoException : Exception
    {
        public EmprestimoNaoEncontradoException(int id)
       : base($"Empréstimo com ID {id} não encontrado.")
        {
        }
    }
}
