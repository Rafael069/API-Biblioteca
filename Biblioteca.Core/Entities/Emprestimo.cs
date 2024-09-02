using Biblioteca.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Entities
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            
            UsuarioId = usuarioId;
            LivroId = livroId;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Status = EmprestimoStatusEnum.Ativo;

        }

        
        public int UsuarioId { get; private set; }
        public int LivroId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public EmprestimoStatusEnum Status { get; set; }
        public Usuario? Usuario { get; private set; }
        public Livro? Livro { get; private set; }


        // renomear
        public string Devolver(DateTime dataDevolucao)
        {
            
            
            var atraso = dataDevolucao.Date.Subtract(DataDevolucao.Date).Days;
            if (atraso > 0)
            {
                Status = EmprestimoStatusEnum.Devolvido;
                return $"Atrasado em {atraso} dias.";
            }
            else
            {
                return "Devolução em dia.";
            }
        }


    }
}
