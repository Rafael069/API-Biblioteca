using Biblioteca.Application.Commands.Livros.DeleteLivro;
using Biblioteca.Application.Commands.Livros.CreateLivro;
using Biblioteca.Application.Commands.Livros.UpdateLivro;
using Biblioteca.Application.Queries.Livros.GetAllLivros;
using Biblioteca.Application.Queries.Livros.GetByIdLivro;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Core.Exceptions;



namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LivrosController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Buscar todo os livros

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {

            var query = new GetAllLivrosQuery();

            var livros = await _mediator.Send(query);

            return Ok(livros);
        }


        // Buscar um livro

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getByIdLivroQuery = new GetByIdLivroQuery(id);

                var livros = await _mediator.Send(getByIdLivroQuery);

                return Ok(livros);
            }
            catch (LivroNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }

        }


        //Cadastrar um livro

        [HttpPost]
        public async Task<IActionResult> PostBook([FromBody] CreateLivroCommand command)
        {
            // Validação
            if (command.Titulo == null)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody] UpdateLivroCommand command)
        {
            if (command.Titulo == null || command.Autor == null || command.ISBN == null || command.AnoPublicacao <= 0)
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

        // Deletar um livro

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteLivroCommand(id);

            await _mediator.Send(command);
            return NoContent();

        }

    }
}

