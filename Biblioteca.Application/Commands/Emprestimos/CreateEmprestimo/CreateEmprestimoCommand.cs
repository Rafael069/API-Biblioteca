using MediatR;

namespace Biblioteca.Application.Commands.Emprestimos.CreateEmprestimo
{
    public class CreateEmprestimoCommand : IRequest<int>
    {
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}
