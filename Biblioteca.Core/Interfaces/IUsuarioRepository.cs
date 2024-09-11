using Biblioteca.Core.Entities;

namespace Biblioteca.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetByIdUsuarioAsync(int id);
        Task AddUsuarioAsync(Usuario usuario);
        Task UpdateUsuarioAsync(Usuario usuario);
        Task DeleteUsuarioAsync(int id);
    }
}
