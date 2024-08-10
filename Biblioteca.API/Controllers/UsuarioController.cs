using Biblioteca.Application.InputModels;
using Biblioteca.Application.Services;
using Biblioteca.Application.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        // Buscar todo os usuarios

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {

            var livros = _usuarioService.GetAll();

            return Ok(livros);
        }


        // Buscar um livro

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livros = _usuarioService.GetById(id);

            if (livros == null)
            {
                return NotFound();
            }

            return Ok(livros);
        }


        [HttpPost]
        public IActionResult PostUser([FromBody] NewUsuarioInputModel inputModel)
        {
            // Exemplo
            if (inputModel.Nome == null)
            {
                return BadRequest();
            }

            var id = _usuarioService.Create(inputModel);

            //return Ok();


            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {

            //Remover
            _usuarioService.Delete(id);

            return NoContent();

        }
    }
}
