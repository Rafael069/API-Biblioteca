//using Biblioteca.Application.Queries.GetByIdLivro;
using Biblioteca.Application.Queries.Usuarios.GetByIdUsuario;
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

namespace Biblioteca.Application.Queries.Usuarios.GetByIdUsuario
{

    public class GetByIdUsuarioQueryHandler : IRequestHandler<GetByIdUsuarioQuery, UsuarioDetailsViewModel>
    {

        private readonly BibliotecaDbContext _dbContext;

        public GetByIdUsuarioQueryHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioDetailsViewModel> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {

            //var usuarios = await _dbContext.Usuarios.SingleOrDefaultAsync(u => u.Id == request.Id);


            // Filtra pelo ID e pelo status Ativo
            var usuarios = await _dbContext.Usuarios
                         .Where(u => u.Id == request.Id && u.Status == UsuarioStatusEnum.Ativo)
                         .SingleOrDefaultAsync();

            if (usuarios == null)
            {
                throw new UsuarioNaoEncontradoException(request.Id);
            }

            var usuarioDetailsViewModel = new UsuarioDetailsViewModel(
                usuarios.Id,
                usuarios.Nome,
                usuarios.Email
                );

            return usuarioDetailsViewModel;
        }
    }
}
