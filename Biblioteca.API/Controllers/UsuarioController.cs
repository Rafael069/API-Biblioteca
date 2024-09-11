using Biblioteca.Application.Commands.Usuarios.DeleteUsuario;
using Biblioteca.Application.Commands.Usuarios.CreateUsuario;
using Biblioteca.Application.Commands.Usuarios.UpdateUsuario;
using Biblioteca.Application.Queries.Usuarios.GetAllUsuarios;
using Biblioteca.Application.Queries.Usuarios.GetByIdUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Core.Exceptions;


namespace Biblioteca.API.Controllers
{

    [ApiController]
    [Route("api/usuarios")]

    public class UsuarioController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Buscar todo os usuarios;

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsuariosQuery();

            var usuarios = await _mediator.Send(query);

            return Ok(usuarios);
        }


        // Buscar um livro

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getByIdUsuarioQuery = new GetByIdUsuarioQuery(id);

                var usuarios = await _mediator.Send(getByIdUsuarioQuery);

                return Ok(usuarios);
            }

            catch (UsuarioNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }
            
        }


        // Criar um Usuário

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUsuarioCommand command)
        {
            
            if (command.Nome == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);


            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }


        // Deletar um Usuário

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUsuarioCommand(id);

            await _mediator.Send(command);
            return NoContent();

        }

        // Atualiza um Usuário

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UpdateUsuarioCommand command)
        {
            if (command.Nome == null || command.Email == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                
                return NotFound(ex.Message);
            }

            return NoContent();
        }

    }
}
