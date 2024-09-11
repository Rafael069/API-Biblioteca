using Biblioteca.Application.ViewModels;
using MediatR;

namespace Biblioteca.Application.Queries.Emprestimos.GetAllEmprestimos
{
    public class GetAllEmprestimosQuery : IRequest<List<EmprestimoViewModel>>
    {
    }
}
