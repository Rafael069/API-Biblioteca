using Biblioteca.Application.InputModels;
using Biblioteca.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Services.Interfaces
{
    public interface IEmprestimoService
    {
        List<EmprestimoViewModel> GetAll();
        EmprestimoDetailsViewModel GetById(int id);
        int Create(NewEmprestimoInputModel inputModel);

    }
}
