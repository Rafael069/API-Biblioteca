using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Entities;
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

namespace Biblioteca.Application.Queries.Livros.GetByIdLivro
{
    public class GetByIdLivroQueryHandler : IRequestHandler<GetByIdLivroQuery, LivroDetailsViewModel>
    {

        private readonly BibliotecaDbContext _dbContext;

        public GetByIdLivroQueryHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<LivroDetailsViewModel> Handle(GetByIdLivroQuery request, CancellationToken cancellationToken)
        {

            // Filtra pelo ID e pelo status Ativo
            var livros = await _dbContext.Livros
                         .Where(l => l.Id == request.Id && l.Status == LivroStatusEnum.Ativo)
                         .SingleOrDefaultAsync();


            if (livros == null)
            {
                throw new LivroNaoEncontradoException(request.Id);
            }


            var livroDetailsViewModel = new LivroDetailsViewModel(
                livros.Id,
                livros.Titulo,
                livros.Autor,
                livros.ISBN,
                livros.AnoPublicacao
                );

            return livroDetailsViewModel;
        }
    }
}
