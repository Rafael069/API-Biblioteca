
namespace Biblioteca.Application.ViewModels
{
    public class EmprestimoDetailsViewModel
    {
        public EmprestimoDetailsViewModel(int id, int usuarioId, int livroId, DateTime dataEmprestimo, DateTime dataDevolucao)
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
        
    }

}
