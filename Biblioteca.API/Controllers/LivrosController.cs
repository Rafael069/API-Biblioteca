using Biblioteca.Application.InputModels;
using Biblioteca.Application.Services;
using Biblioteca.Core.Enum;
using Microsoft.AspNetCore.Mvc;



namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }


        // Buscar todo os livros

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            
            var livros = _livroService.GetAll();
            
            return Ok(livros);
        }

        // Buscar um livro

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livros = _livroService.GetById(id);

            if(livros == null)
            {
                return NotFound();
            }

            return Ok(livros);
        }

        // Cadastrar um livro

        [HttpPost]
        public IActionResult PostBook([FromBody] NewLivroInputModel inputModel)
        {
            // Exemplo
            if (inputModel.Titulo == null)
            {
                return BadRequest();
            }

            var id = _livroService.Create(inputModel);

            //return Ok();


            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

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
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, [FromBody] UpdateLivroInputModel updateLivro)
        {
            if (updateLivro.Titulo == null || updateLivro.Autor == null || updateLivro.ISBN == null || updateLivro.AnoPublicacao <= 0)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                _livroService.Update(id, updateLivro);
            }
            catch (Exception ex)
            {
                // Você pode ter um tratamento de exceções mais elaborado
                return NotFound(ex.Message);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

            //Remover
            _livroService.Delete(id);

            return NoContent();

        }
    }
}

