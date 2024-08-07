using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.InputModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }

    }
}
