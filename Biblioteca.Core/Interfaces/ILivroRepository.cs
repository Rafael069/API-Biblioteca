using Biblioteca.Core.Entities;

namespace Biblioteca.Core.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllLivrosAsync();
        Task<Livro> GetByIdLivroAsync(int id);        
        Task AddLivroAsync(Livro livro);
        Task UpdateLivroAsync(Livro livro); 
    }
}
