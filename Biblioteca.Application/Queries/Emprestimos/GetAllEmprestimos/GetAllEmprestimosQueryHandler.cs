using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Interfaces;
using MediatR;

namespace Biblioteca.Application.Queries.Emprestimos.GetAllEmprestimos
{
    public class GetAllEmprestimosQueryHandler : IRequestHandler<GetAllEmprestimosQuery, List<EmprestimoViewModel>>
    {

        private readonly IEmprestimoRepository _emprestimoRepository;

        public GetAllEmprestimosQueryHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<List<EmprestimoViewModel>> Handle(GetAllEmprestimosQuery request, CancellationToken cancellationToken)
        {

            // Obtém todos os empréstimos ativos do repositório
            var emprestimosAtivos = await _emprestimoRepository.GetAllEmprestimosAsync();


            var emprestimosViewModel = emprestimosAtivos
                .Select(e => new EmprestimoViewModel(e.Id, e.UsuarioId, e.LivroId, e.DataEmprestimo, e.DataDevolucao))
                .ToList();

            return emprestimosViewModel;
        }
    }
}
