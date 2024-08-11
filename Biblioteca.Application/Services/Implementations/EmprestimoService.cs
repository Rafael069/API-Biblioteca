using Biblioteca.Application.InputModels;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Entities;
using Biblioteca.Infrastructure.Persistence;


namespace Biblioteca.Application.Services.Implementations
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly BibliotecaDbContext _dbContext;

        public EmprestimoService(BibliotecaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EmprestimoViewModel> GetAll()
        {
            var emprestimos = _dbContext.Emprestimos;


            var emprestimosViewModel = emprestimos
               .Select(e => new EmprestimoViewModel(e.Id, e.UsuarioId, e.LivroId, e.DataEmprestimo, e.DataDevolucao))
               .ToList();


            return emprestimosViewModel;
        }



        //public UsuarioDetailsViewModel GetById(int id)
        //{
        //    //throw new NotImplementedException();


        //    var usuarios = _dbContext.Usuarios.SingleOrDefault(u => u.Id == id);

        //    var usuarioDetailsViewModel = new UsuarioDetailsViewModel(
        //        usuarios.Id,
        //        usuarios.Nome,
        //        usuarios.Email
        //        );

        //    return usuarioDetailsViewModel;
        //}

        public EmprestimoDetailsViewModel GetById(int id)
        {
            //throw new NotImplementedException();
            //Id = id;
            //UsuarioId = usuarioId;
            //LivroId = livroId;
            //DataEmprestimo = DateTime.Now;
            //DataDevolucao = dataDevolucao;


            var emprestimos = _dbContext.Emprestimos.SingleOrDefault(e => e.Id == id);


            if (emprestimos == null)
            {
                return null; // Ou você pode lançar uma exceção
            }

            // Obter o usuário associado
            //var usuario = _dbContext.Usuarios.SingleOrDefault(u => u.Id == emprestimos.UsuarioId);

            var emprestimoDetailsViewModel = new EmprestimoDetailsViewModel(
                emprestimos.Id,
                emprestimos.UsuarioId,
                emprestimos.LivroId,
                emprestimos.DataEmprestimo,
                emprestimos.DataDevolucao
                //usuario // Passar o usuário ao construtor do view model
                );

            return emprestimoDetailsViewModel;
        }
        public int Create(NewEmprestimoInputModel inputModel)
        {
            var novoEmprestimo = new Emprestimo(
                _dbContext.Emprestimos.Max(e => e.Id) + 1,
                //inputModel.Id,
                inputModel.UsuarioId,
                inputModel.LivroId,
                inputModel.DataEmprestimo,
                inputModel.DataDevolucao
            );

            _dbContext.Emprestimos.Add(novoEmprestimo);
            return novoEmprestimo.Id;
        }


    }
}
