using Biblioteca.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Entities
{
    public class Livro /*: BaseEntity*/
    {
        public Livro(int id,string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
            Status = LivroStatusEnum.Ativo;

            Emprestimos = new List<Emprestimo>();
        }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public LivroStatusEnum Status { get; set; }
        public List<Emprestimo> Emprestimos { get; private set; }



        public void Cancel()
        {
            if (Status == LivroStatusEnum.Ativo)
            {
                Status = LivroStatusEnum.Removido;
            }
        }


        public void Update(string titulo, string autor, string isbn, int anoPublicacao)
        {
            Titulo = titulo;   
            Autor = autor;
            ISBN = isbn;
            AnoPublicacao = anoPublicacao;

        }


        

    }
}
