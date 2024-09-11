using Biblioteca.Application.ViewModels;
using MediatR;


namespace Biblioteca.Application.Queries.Emprestimos.GetByEmprestimo
{
    public class GetByIdEmprestimoQuery : IRequest<EmprestimoDetailsViewModel>
    {
        public GetByIdEmprestimoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
