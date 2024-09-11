using Biblioteca.Core.Entities;
using Biblioteca.Core.Interfaces;
using MediatR;


namespace Biblioteca.Application.Commands.Emprestimos.CreateEmprestimo
{
    public class CreateEmprestimoCommandHandler : IRequestHandler<CreateEmprestimoCommand, int>
    {

        private readonly IEmprestimoRepository _emprestimoRepository;

        public CreateEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public async Task<int> Handle(CreateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var novoEmprestimo = new Emprestimo(
                request.UsuarioId,
                request.LivroId,
                request.DataEmprestimo,
                request.DataDevolucao
            );

            /// Adiciona o novo empréstimo usando o repositório
            await _emprestimoRepository.AddEmprestimoAsync(novoEmprestimo);

            return novoEmprestimo.Id;
        }
    }
}
