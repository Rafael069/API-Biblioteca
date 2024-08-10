using Biblioteca.Application.InputModels;
using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Entities;
using Biblioteca.Core.Enum;
using Biblioteca.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BibliotecaDbContext _dbContext;

        public UsuarioService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int id)
        {
            var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == id);

            usuario.Cancel();

        }

        public List<UsuarioViewModel> GetAll()
        {
            var usuarios = _dbContext.Usuarios;

            // Filtrando livros ativos
            var usuariosAtivos = _dbContext.Usuarios
                .Where(u => u.Status == UsuarioStatusEnum.Ativo)
                .ToList();


            var usuariosViewModel = usuarios
              .Select(u => new UsuarioViewModel(u.Id,u.Nome, u.Email))
              .ToList();

            

            return usuariosViewModel;
        }

        public UsuarioDetailsViewModel GetById(int id)
        {
            //throw new NotImplementedException();


            var usuarios = _dbContext.Usuarios.SingleOrDefault(u => u.Id == id);

            var usuarioDetailsViewModel = new UsuarioDetailsViewModel(
                usuarios.Id,
                usuarios.Nome,
                usuarios.Email
                );

            return usuarioDetailsViewModel;
        }

        public int Create(NewUsuarioInputModel inputModel)
        {
            var usuario = new Usuario(inputModel.Id, inputModel.Nome, inputModel.Email);
            _dbContext.Usuarios.Add(usuario);

            return usuario.Id;

        }
    }
}
