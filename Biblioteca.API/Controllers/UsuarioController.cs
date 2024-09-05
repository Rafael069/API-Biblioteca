//using Biblioteca.Application.Commands.Livros.DeleteLivro;
using Biblioteca.Application.Commands.Usuarios.DeleteUsuario;
using Biblioteca.Application.Commands.Usuarios.CreateUsuario;
using Biblioteca.Application.Commands.Usuarios.UpdateUsuario;
//using Biblioteca.Application.InputModels;
//using Biblioteca.Application.Queries.Livros.GetAllLivros;
using Biblioteca.Application.Queries.Usuarios.GetAllUsuarios;
//using Biblioteca.Application.Queries.Livros.GetByIdLivro;
using Biblioteca.Application.Queries.Usuarios.GetByIdUsuario;
//using Biblioteca.Application.Services;
//using Biblioteca.Application.Services.Implementations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Biblioteca.Core.Exceptions;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {

        //private readonly IUsuarioService _usuarioService;
        private readonly IMediator _mediator;
        public UsuarioController(/*IUsuarioService usuarioService, */IMediator mediator)
        {
            //_usuarioService = usuarioService;
            _mediator = mediator;
        }


        // Buscar todo os usuarios

        //[HttpGet]
        //[Route("all")]
        //public IActionResult GetAll()
        //{

        //    var livros = _usuarioService.GetAll();

        //    return Ok(livros);
        //}

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsuariosQuery();

            var usuarios = await _mediator.Send(query);

            return Ok(usuarios);
        }

        // Buscar um livro

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var livros = _usuarioService.GetById(id);

        //    if (livros == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(livros);
        //}

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

        //[HttpPost]
        //public IActionResult PostUser([FromBody] NewUsuarioInputModel inputModel)
        //{
        //    // Exemplo
        //    if (inputModel.Nome == null)
        //    {
        //        return BadRequest();
        //    }

        //    var id = _usuarioService.Create(inputModel);

        //    //return Ok();


        //    return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        //}


        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUsuarioCommand command)
        {
            // Exemplo
            if (command.Nome == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);


            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUser(int id)
        //{

        //    //Remover
        //    _usuarioService.Delete(id);

        //    return NoContent();

        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var command = new DeleteUsuarioCommand(id);

            await _mediator.Send(command);
            return NoContent();

        }




        //[HttpPut("{id}")]
        //public IActionResult PutUser([FromBody] UpdateUsuarioInputModel inputModel)
        //{
        //    if (inputModel.Nome == null || inputModel.Email == null)
        //    {
        //        return BadRequest("Dados inválidos.");
        //    }

        //    try
        //    {
        //        _usuarioService.Update(inputModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Tratamento de exceções mais elaborado pode ser necessário
        //        return NotFound(ex.Message);
        //    }

        //    return NoContent();
        //}


        [HttpPut("{id}")]
        //[HttpPut]
        public async Task<IActionResult> PutUser([FromBody] UpdateUsuarioCommand command)
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
                // Tratamento de exceções mais elaborado pode ser necessário
                return NotFound(ex.Message);
            }

            return NoContent();
        }



    }
}
