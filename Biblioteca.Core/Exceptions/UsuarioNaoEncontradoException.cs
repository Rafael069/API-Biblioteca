using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
