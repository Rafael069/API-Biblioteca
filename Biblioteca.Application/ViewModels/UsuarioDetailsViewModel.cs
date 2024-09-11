using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.ViewModels
{
    public class UsuarioDetailsViewModel
    {
        public UsuarioDetailsViewModel(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

    }
}
