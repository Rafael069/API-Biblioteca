using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Exceptions;
using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Queries.Emprestimos.GetByEmprestimo
{
    public class GetByIdEmprestimoQueryHandler : IRequestHandler<GetByIdEmprestimoQuery, EmprestimoDetailsViewModel>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public GetByIdEmprestimoQueryHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<EmprestimoDetailsViewModel> Handle(GetByIdEmprestimoQuery request, CancellationToken cancellationToken)
        {

            var emprestimo = await _emprestimoRepository.GetByIdEmprestimoAsync(request.Id);


            if (emprestimo == null)
            {
                throw new EmprestimoNaoEncontradoException(request.Id);
            }

            var emprestimoDetailsViewModel = new EmprestimoDetailsViewModel(
                emprestimo.Id,
                emprestimo.UsuarioId,
                emprestimo.LivroId,
                emprestimo.DataEmprestimo,
                emprestimo.DataDevolucao
                );

            return emprestimoDetailsViewModel;
        }
    }
}
