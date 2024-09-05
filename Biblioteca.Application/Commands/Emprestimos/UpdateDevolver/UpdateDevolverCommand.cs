using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Biblioteca.Application.Commands.Emprestimos.UpdateDevolver
{
    //    public class UpdateDevolverCommand : IRequest<String>
    //    {
    //        public int Id { get; set; }
    //        public DateTime DataDevolucao { get; set; }
    //    }
    //}

    public class UpdateDevolverCommand : IRequest<DevolverResult>
    {
        public int Id { get; set; }
        public DateTime DataDevolucao { get; set; }
    }

}