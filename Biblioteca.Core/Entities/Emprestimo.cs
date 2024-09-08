using Biblioteca.Core.Enum;


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



        public string Devolver(DateTime dataDevolucao)
        {


            // Calcula a diferença em dias considerando a data de devolução completa
            var atraso = (dataDevolucao.Date - DataDevolucao.Date).Days;

            // Atualiza o status
            if (atraso > 0)
            {
                DataDevolucao = dataDevolucao;
                Status = EmprestimoStatusEnum.Devolvido;
                return $"Atrasado em {atraso} dias.";
            }
            else
            {
                Status = EmprestimoStatusEnum.Devolvido;
                return "Devolução em dia.";
            }
        }




    }
}
