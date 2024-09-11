using MediatR;


namespace Biblioteca.Application.Commands.Emprestimos.UpdateDevolver
{
    public class UpdateDevolverCommand : IRequest<DevolverResult>
    {
        public int Id { get; set; }
        public DateTime DataDevolucao { get; set; }
    }

}