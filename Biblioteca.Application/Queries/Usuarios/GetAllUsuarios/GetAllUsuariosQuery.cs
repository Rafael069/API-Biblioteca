﻿using Biblioteca.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Queries.Usuarios.GetAllUsuarios
{
    public class GetAllUsuariosQuery : IRequest<List<UsuarioViewModel>>
    {
    }
}
