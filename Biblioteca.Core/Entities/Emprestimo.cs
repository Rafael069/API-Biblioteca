using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Entities
{
    public class Emprestimo /*: BaseEntity*/
    {
        public Emprestimo(int id, int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataDevolucao)
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

        public void UpdateDataDevolucao(DateTime dataDevolucao)
        {
            DataDevolucao = dataDevolucao;
        }

        public string GetStatusDevolucao(DateTime dataDevolucao)
        {
            //var hoje = DateTime.Now;
            
            var atraso = dataDevolucao.Date.Subtract(DataDevolucao.Date).Days;
            if (atraso > 0)
            {
                return $"Atrasado em {atraso} dias.";
            }
            else
            {
                return "Devolução em dia.";
            }
        }

        //public string VerificarStatusDevolucao()
        //{
        //    if (DataDevolucao.HasVlue)
        //    {
        //        var hoje = DateTime.Now;
        //        var atraso = hoje.Date.Subtract(DataDevolucao.Value.Date).Days;
        //        if (atraso > 0)
        //        {
        //            return $"Atrasado em {atraso} dias.";
        //        }
        //        else
        //        {
        //            return "Devolução em dia.";
        //        }
        //    }
        //    return "Livro ainda não devolvido.";
        //}


    }
}
