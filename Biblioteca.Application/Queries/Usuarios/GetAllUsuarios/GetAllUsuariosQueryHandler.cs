//using Biblioteca.Application.Queries.GetAllLivros;
using Biblioteca.Application.Queries.Usuarios.GetAllUsuarios;
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

namespace Biblioteca.Application.Queries.Usuarios.GetAllUsuarios
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, List<UsuarioViewModel>>
    {
        private readonly BibliotecaDbContext _dbContext;

        public GetAllUsuariosQueryHandler(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioViewModel>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = _dbContext.Usuarios;

            // Filtrando livros ativos
            var usuariosAtivos = await _dbContext.Usuarios
                .Where(u => u.Status == UsuarioStatusEnum.Ativo)
                .ToListAsync();


            var usuariosViewModel = usuariosAtivos
              .Select(u => new UsuarioViewModel(u.Id, u.Nome, u.Email))
              .ToList();

            return usuariosViewModel;
        }
    }
}
