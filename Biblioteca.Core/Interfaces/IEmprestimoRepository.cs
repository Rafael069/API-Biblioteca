using Biblioteca.Core.Entities;

namespace Biblioteca.Core.Interfaces
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> GetAllEmprestimosAsync();
        Task<Emprestimo> GetByIdEmprestimoAsync(int id);
        Task AddEmprestimoAsync(Emprestimo emprestimo);
        Task UpdateEmprestimoAsync(Emprestimo emprestimo);
    }
}
