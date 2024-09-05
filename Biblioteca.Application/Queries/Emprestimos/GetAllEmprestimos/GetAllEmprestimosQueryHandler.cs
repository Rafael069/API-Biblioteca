//using Biblioteca.Application.Queries.GetAllLivros;
using Biblioteca.Application.Queries.Emprestimos.GetAllEmprestimos;
using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Enum;
using Biblioteca.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.Emprestimos.GetAllEmprestimos
{
    public class GetAllEmprestimosQueryHandler : IRequestHandler<GetAllEmprestimosQuery, List<EmprestimoViewModel>>
    {
        private readonly BibliotecaDbContext _dbContext;

        public GetAllEmprestimosQueryHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmprestimoViewModel>> Handle(GetAllEmprestimosQuery request, CancellationToken cancellationToken)
        {
            var emprestimos = _dbContext.Emprestimos;


            var emprestimosAtivos = await _dbContext.Emprestimos
                .Where(l => l.Status == EmprestimoStatusEnum.Ativo)
                .ToListAsync();

            var emprestimosViewModel = emprestimosAtivos
                .Select(e => new EmprestimoViewModel(e.Id, e.UsuarioId, e.LivroId, e.DataEmprestimo, e.DataDevolucao))
                .ToList();

            return emprestimosViewModel;
        }
    }
}
