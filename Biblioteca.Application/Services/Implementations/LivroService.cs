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
    public class LivroService : ILivroService
    {
        private readonly BibliotecaDbContext _dbContext;

        public LivroService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(NewLivroInputModel inputModel)
        {
            var livro = new Livro(/*inputModel.Id,*/inputModel.Titulo, inputModel.Autor, inputModel.ISBN, inputModel.AnoPublicacao);
            _dbContext.Livros.Add(livro);
            _dbContext.SaveChanges();

            return livro.Id;

        }

        public void Delete(int id)
        {
            var livro = _dbContext.Livros.SingleOrDefault(l => l.Id == id);

            livro.Cancel();
            _dbContext.SaveChanges();
        }

        public List<LivroViewModel> GetAll()
        {
            var livros = _dbContext.Livros;

            // Filtrando livros ativos
            var livrosAtivos = _dbContext.Livros
                .Where(l => l.Status == LivroStatusEnum.Ativo)
                .ToList();

            var livrosViewModel = livrosAtivos
            .Select(l => new LivroViewModel(l.Id, l.Titulo, l.Autor))
            .ToList();

            return livrosViewModel;
        }

        public LivroDetailsViewModel GetById(int id)
        {

            //var livros = _dbContext.Livros.SingleOrDefault(l => l.Id == id);


            // Filtra pelo ID e pelo status Ativo
            var livros = _dbContext.Livros
                                  .Where(l => l.Id == id && l.Status == LivroStatusEnum.Ativo)
                                  .SingleOrDefault();

            var livroDetailsViewModel = new LivroDetailsViewModel(
                livros.Id,
                livros.Titulo,
                livros.Autor,
                livros.ISBN,
                livros.AnoPublicacao
                );

            return livroDetailsViewModel;
        }

        public void Update(int id, UpdateLivroInputModel inputModel)
        {
            var livro = _dbContext.Livros.SingleOrDefault(l => l.Id == id);

            if (livro == null)
            {
                throw new Exception("Livro não encontrado.");
            }

            livro.Update(inputModel.Titulo, inputModel.Autor,inputModel.ISBN,inputModel.AnoPublicacao);
            _dbContext.SaveChanges();
        }

    }
}
