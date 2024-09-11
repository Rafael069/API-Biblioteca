using Biblioteca.Core.Entities;
using Biblioteca.Core.Enum;
using Biblioteca.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public EmprestimoRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Emprestimo>> GetAllEmprestimosAsync()
        {
            return await _dbContext.Emprestimos
                .Where(e => e.Status == EmprestimoStatusEnum.Ativo) // Se desejar filtrar apenas empréstimos ativos
                .ToListAsync();
        }

        public async Task<Emprestimo> GetByIdEmprestimoAsync(int id)
        {
            return await _dbContext.Emprestimos
                .Where(e => e.Id == id && e.Status == EmprestimoStatusEnum.Ativo) 
                .SingleOrDefaultAsync();
        }

        public async Task AddEmprestimoAsync(Emprestimo emprestimo)
        {
            await _dbContext.Emprestimos.AddAsync(emprestimo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmprestimoAsync(Emprestimo emprestimo)
        {
            _dbContext.Emprestimos.Update(emprestimo); 
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
