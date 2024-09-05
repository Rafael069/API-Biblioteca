using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
