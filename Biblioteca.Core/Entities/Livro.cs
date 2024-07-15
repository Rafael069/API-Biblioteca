using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Entities
{
    public class Livro : BaseEntity
    {
        public Livro(string titulo, string autor, string iSBN, int anoPublicacao)
        {         
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;

            Emprestimos = new List<Emprestimo>();
        }

            
            public string Titulo { get; private set; }
            public string Autor { get; private set; }
            public string ISBN { get; private set; }
            public int AnoPublicacao { get; private set; }

            public List<Emprestimo> Emprestimos { get; private set; }

    }
}
