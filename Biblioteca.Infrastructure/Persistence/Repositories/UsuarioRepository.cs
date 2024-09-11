using Biblioteca.Core.Entities;
using Biblioteca.Core.Enum;
using Biblioteca.Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public UsuarioRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _dbContext.Usuarios
                .Where(u => u.Status == UsuarioStatusEnum.Ativo)
                .ToListAsync();
        }

        public async Task<Usuario> GetByIdUsuarioAsync(int id)
        {
            return await _dbContext.Usuarios
                         .Where(u => u.Id == id && u.Status == UsuarioStatusEnum.Ativo)
                         .SingleOrDefaultAsync();
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
        
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }
    }
}
