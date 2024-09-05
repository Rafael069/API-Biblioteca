using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
