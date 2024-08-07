using Biblioteca.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    public class UsuarioController : ControllerBase
    {
        [ApiController]
        [Route("usuario/livros")]

        private readonly IUsuarioService _usuarioService;


    }
}
