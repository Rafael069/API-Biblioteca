using Biblioteca.Core.Entities;
using Biblioteca.Core.Enum;
using Biblioteca.Core.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroRepository(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Livro>> GetAllLivrosAsync()
        {
            return await _dbContext.Livros
                 .Where(l => l.Status == LivroStatusEnum.Ativo) 
                 .ToListAsync();
        }

        public async Task<Livro> GetByIdLivroAsync(int id)
        {
            // Filtra pelo ID e pelo status Ativo

            return await _dbContext.Livros
                         .Where(l => l.Id == id && l.Status == LivroStatusEnum.Ativo)
                         .SingleOrDefaultAsync();
        }

        public async Task AddLivroAsync(Livro livro)
        {
            await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLivroAsync(Livro livro)
        {
            _dbContext.Livros.Update(livro); 
            await _dbContext.SaveChangesAsync();
        }
    }
}
