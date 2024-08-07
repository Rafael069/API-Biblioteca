using Biblioteca.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Persistence
{
    public class BibliotecaDbContext
    {
        public BibliotecaDbContext()
        {
            Livros = new List<Livro>
            {
                new Livro(1,"Primeiro livro 1","João1", "9780312150605",2022),
                new Livro(2,"Primeiro livro 2", "João2", "9780312150606", 2023),
                new Livro(3,"Primeiro livro 3", "João3", "9780312150607", 2024)
            };


            Usuarios = new List<Usuario>
            {
                new Usuario("Rafael","rafael@gmail.com"),
                new Usuario("Ana","ana@gmail.com"),
                new Usuario("Pedro","pedro@gmail.com")
            };

            Emprestimos = new List<Emprestimo>
            {
                new Emprestimo(1,1,DateTime.Now,new DateTime(2024,07,22)),
                new Emprestimo(2,2,DateTime.Now,new DateTime(2024,08,22)),
                new Emprestimo(3,3,DateTime.Now,new DateTime(2024,09,22))
            };
        }

        public List<Livro> Livros { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }


        //public string Titulo { get; private set; }
        //public string Autor { get; private set; }
        //public string ISBN { get; private set; }
        //public int AnoPublicacao { get; private set; }

        //public List<Emprestimo> Emprestimos { get; private set; }
    }
}
