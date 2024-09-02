using Biblioteca.Application.InputModels;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Application.ViewModels;
using Biblioteca.Core.Entities;
using Biblioteca.Core.Enum;
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


            var emprestimosAtivos = _dbContext.Emprestimos
                .Where(l => l.Status == EmprestimoStatusEnum.Ativo)
                .ToList();

            var emprestimosViewModel = emprestimosAtivos
                .Select(e => new EmprestimoViewModel(e.Id, e.UsuarioId, e.LivroId, e.DataEmprestimo, e.DataDevolucao))
                .ToList();

            //var emprestimosViewModel = emprestimos
            //   .Select(e => new EmprestimoViewModel(e.Id, e.UsuarioId, e.LivroId, e.DataEmprestimo, e.DataDevolucao))
            //   .ToList();


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

           
            var emprestimos = _dbContext.Emprestimos.Where(e => e.Id == id && e.Status == EmprestimoStatusEnum.Ativo)
                                                    .SingleOrDefault();

            if (emprestimos == null)
            {
                return null;
            }

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
                inputModel.UsuarioId,
                inputModel.LivroId,
                inputModel.DataEmprestimo,
                inputModel.DataDevolucao
            );

            _dbContext.Emprestimos.Add(novoEmprestimo);
            _dbContext.SaveChanges();

            return novoEmprestimo.Id;
        }


        public string Devolver(UpdateEmprestimoInputModel inputModel)
        {
            var emprestimo = _dbContext.Emprestimos.SingleOrDefault(e => e.Id == inputModel.Id);
            if (emprestimo != null)
            {
                //return emprestimo.GetStatusDevolucao();
                return emprestimo.Devolver(inputModel.DataDevolucao);
            }
            else
            {
                throw new Exception("Empréstimo não encontrado.");
            }
        }

    }
}
