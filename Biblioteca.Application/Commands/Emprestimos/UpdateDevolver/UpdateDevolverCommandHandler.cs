using Biblioteca.Application.Commands.Emprestimos.UpdateDevolver;
using Biblioteca.Core.Interfaces;
using MediatR;

public class UpdateDevolverCommandHandler : IRequestHandler<UpdateDevolverCommand, DevolverResult>
{

    private readonly IEmprestimoRepository _emprestimoRepository;

    public UpdateDevolverCommandHandler(IEmprestimoRepository emprestimoRepository)
    {
        _emprestimoRepository = emprestimoRepository;
    }

    public async Task<DevolverResult> Handle(UpdateDevolverCommand request, CancellationToken cancellationToken)
    {

        // Obtém o empréstimo do repositório com base no ID fornecido
        var emprestimo = await _emprestimoRepository.GetByIdEmprestimoAsync(request.Id);

        if (emprestimo == null)
        {
            throw new Exception("Empréstimo não encontrado.");
        }

        // Atualiza a data de devolução e o status
        var mensagem = emprestimo.Devolver(request.DataDevolucao);


        // Atualiza o empréstimo no repositório
        await _emprestimoRepository.UpdateEmprestimoAsync(emprestimo);

        return new DevolverResult { Mensagem = mensagem };
      
    }
}


