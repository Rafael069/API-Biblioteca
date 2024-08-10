using Biblioteca.Application.InputModels;
using Biblioteca.Application.ViewModels;

namespace Biblioteca.Application.Services
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> GetAll();
        UsuarioDetailsViewModel GetById(int id);
        int Create(NewUsuarioInputModel inputModel);
        void Delete(int id);
    }
}
