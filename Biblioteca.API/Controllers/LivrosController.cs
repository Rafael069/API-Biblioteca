using Biblioteca.Application.Commands.Livros.DeleteLivro;
using Biblioteca.Application.Commands.Livros.CreateLivro;
using Biblioteca.Application.Commands.Livros.UpdateLivro;


//using Biblioteca.Application.InputModels;
using Biblioteca.Application.Queries.Livros.GetAllLivros;
using Biblioteca.Application.Queries.Livros.GetByIdLivro;
//using Biblioteca.Application.Services;
using Biblioteca.Core.Enum;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Core.Exceptions;



namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        //private readonly ILivroService _livroService;
        private readonly IMediator _mediator;

        public LivrosController(/*ILivroService livroService,*/ IMediator mediator)
        {
            //_livroService = livroService;
            _mediator = mediator;
        }


        // Buscar todo os livros

        //[HttpGet]
        //[Route("all")]
        //public IActionResult GetAll()
        //{

        //    var livros = _livroService.GetAll();

        //    return Ok(livros);
        //}


        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {

            var query = new GetAllLivrosQuery();

            var livros = await _mediator.Send(query);

            return Ok(livros);
        }



        // Buscar um livro

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var livros = _livroService.GetById(id);

        //    if(livros == null)
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




        //// Cadastrar um livro

        //[HttpPost]
        //public IActionResult PostBook([FromBody] NewLivroInputModel inputModel)
        //{
        //    // Exemplo
        //    if (inputModel.Titulo == null)
        //    {
        //        return BadRequest();
        //    }

        //    var id = _livroService.Create(inputModel);

        //    //return Ok();


        //    return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        //}


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





        // Atualizar um livro

        //[HttpPut("{id}")]
        //public IActionResult PutBook(int id, [FromBody] UpdateLivroInputModel updateLivro)
        //{
        //    // Exemplo
        //    //if (updateLivro.descricao.lengh > 50)
        //    //{
        //    //    return BadRequest();
        //    //}


        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public IActionResult PutBook(int id, [FromBody] UpdateLivroInputModel updateLivro)
        //{
        //    if (updateLivro.Titulo == null || updateLivro.Autor == null || updateLivro.ISBN == null || updateLivro.AnoPublicacao <= 0)
        //    {
        //        return BadRequest("Dados inválidos.");
        //    }

        //    try
        //    {
        //        _livroService.Update(id, updateLivro);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Você pode ter um tratamento de exceções mais elaborado
        //        return NotFound(ex.Message);
        //    }

        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        [HttpPut]

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



        //[HttpDelete("{id}")]
        //public IActionResult DeleteBook(int id)
        //{

        //    //Remover
        //    _livroService.Delete(id);

        //    return NoContent();

        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var command = new DeleteLivroCommand(id);

            await _mediator.Send(command);
            return NoContent();

        }

    }
}

