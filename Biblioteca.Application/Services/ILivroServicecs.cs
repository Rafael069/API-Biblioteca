using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services
{
    public interface ILivroServicecs
    {
        List<LivroViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        int Create(NewLivroInputModel inputModel);
        int Update(UpdateLivroInputModel inputModel);
    }
}
