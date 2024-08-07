using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.ViewModels
{
    public class LivroViewModel
    {
        public LivroViewModel(int id,string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
        }
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
    }
}
