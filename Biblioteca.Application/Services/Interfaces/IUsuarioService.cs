
using Biblioteca.Application.ViewModels;

namespace Biblioteca.Application.Services
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> GetAll();
    }
}
