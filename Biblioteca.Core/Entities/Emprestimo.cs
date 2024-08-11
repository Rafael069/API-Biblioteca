using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Entities
{
    public class Emprestimo /*: BaseEntity*/
    {
        public Emprestimo(int id,int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Id = id;
            UsuarioId = usuarioId;
            LivroId = livroId;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = dataDevolucao;
            
        }

            public int Id { get; private set; }
            public int UsuarioId { get; private set; }
            public int LivroId { get; private set; }
            public DateTime DataEmprestimo { get; private set; }
            public DateTime DataDevolucao { get; private set; }

            public Usuario? Usuario { get; private set; }
            public Livro? Livro { get; private set; }
        

    }
}
