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

namespace Biblioteca.Application.Queries.Livros.GetAllLivros
{
    public class GetAllLivrosQueryHandler : IRequestHandler<GetAllLivrosQuery, List<LivroViewModel>>
    {
        private readonly BibliotecaDbContext _dbContext;

        public GetAllLivrosQueryHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<LivroViewModel>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = _dbContext.Livros;

            // Filtrando livros ativos
            var livrosAtivos = await _dbContext.Livros
                .Where(l => l.Status == LivroStatusEnum.Ativo)
                //.ToListAsync(cancellationToken);
                .ToListAsync();

            var livrosViewModel = livrosAtivos
            .Select(l => new LivroViewModel(l.Id, l.Titulo, l.Autor))
            .ToList();

            return livrosViewModel;
        }
    }
}
