//using Biblioteca.Infrastructure.Persistence;
//using DevFreela.Application.Commands.UpdateProject;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Biblioteca.Application.Commands.UpdateDevolver
//{
//    public class UpdateDevolverCommandHandler : IRequestHandler<UpdateDevolverCommand, String>
//    {

//        private readonly BibliotecaDbContext _dbContext;

//        public UpdateDevolverCommandHandler(BibliotecaDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<string> Handle(UpdateDevolverCommand request, CancellationToken cancellationToken)
//        {
//            // Obtém o empréstimo do banco de dados com base no ID fornecido
//            var emprestimo = _dbContext.Emprestimos.SingleOrDefault(e => e.Id == request.Id);

//            // Verifica se o empréstimo foi encontrado
//            if (emprestimo != null)
//            {
//                // Atualiza a data de devolução e o status
//                var status = emprestimo.Devolver(request.DataDevolucao);

//                // Salva as mudanças no banco de dados
//                await _dbContext.SaveChangesAsync();

//                return status;
//            }
//            else
//            {
//                throw new Exception("Empréstimo não encontrado.");
//            }
//        }

//    }
//}




using Biblioteca.Application.Commands.Emprestimos.UpdateDevolver;
using Biblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class UpdateDevolverCommandHandler : IRequestHandler<UpdateDevolverCommand, DevolverResult>
{
    private readonly BibliotecaDbContext _dbContext;

    public UpdateDevolverCommandHandler(BibliotecaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DevolverResult> Handle(UpdateDevolverCommand request, CancellationToken cancellationToken)
    {
        // Obtém o empréstimo do banco de dados com base no ID fornecido
        var emprestimo = await _dbContext.Emprestimos.SingleOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        // Verifica se o empréstimo foi encontrado
        if (emprestimo == null)
        {
            // Lançar uma exceção específica ou retornar um resultado de erro
            //throw new EmprestimoNaoEncontradoException(request.Id);
            throw new Exception("Empréstimo não encontrado.");
        }

        // Atualiza a data de devolução e o status
        var mensagem = emprestimo.Devolver(request.DataDevolucao);

        // Salva as mudanças no banco de dados
        await _dbContext.SaveChangesAsync();

        return new DevolverResult { Mensagem = mensagem };

      
    }
}


