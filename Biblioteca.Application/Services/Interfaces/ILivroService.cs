using Biblioteca.Application.InputModels;
using Biblioteca.Application.ViewModels;


namespace Biblioteca.Application.Services
{
    public interface ILivroService
    {
        List<LivroViewModel> GetAll();
        LivroDetailsViewModel GetById(int id);
        int Create(NewLivroInputModel inputModel);
        //void Update(UpdateLivroInputModel inputModel);
        void Delete(int id);
    }
}
