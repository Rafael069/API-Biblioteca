//using Biblioteca.Application.Queries.GetByIdLivro;
using Biblioteca.Application.Queries.Emprestimos.GetByEmprestimo;
using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Enum;
using Biblioteca.Core.Exceptions;
using Biblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.Emprestimos.GetByEmprestimo
{
    public class GetByIdEmprestimoQueryHandler : IRequestHandler<GetByIdEmprestimoQuery, EmprestimoDetailsViewModel>
    {

        private readonly BibliotecaDbContext _dbContext;

        public GetByIdEmprestimoQueryHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EmprestimoDetailsViewModel> Handle(GetByIdEmprestimoQuery request, CancellationToken cancellationToken)
        {
            var emprestimos = await _dbContext.Emprestimos
                .Where(e => e.Id == request.Id && e.Status == EmprestimoStatusEnum.Ativo)
                .SingleOrDefaultAsync();


            if (emprestimos == null)
            {
                throw new EmprestimoNaoEncontradoException(request.Id);
            }

            var emprestimoDetailsViewModel = new EmprestimoDetailsViewModel(
                emprestimos.Id,
                emprestimos.UsuarioId,
                emprestimos.LivroId,
                emprestimos.DataEmprestimo,
                emprestimos.DataDevolucao
                //usuario // Passar o usuário ao construtor do view model
                );

            return emprestimoDetailsViewModel;
        }
    }
}
