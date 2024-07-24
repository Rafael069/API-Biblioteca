using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    
    [Route("api/livros")]
    public class LivrosController : ControllerBase
    {
        // Buscar todo os livros

        [HttpGet]
        public IActionResult Get(string query)
        {

            
            return Ok(query);
        }

        // Buscar o livro

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            
            return Ok(query);
        }

        // cadastrar um livro

        [HttpPost]
        public IActionResult Post([FromBody] CreaLivroModel createLivro)
        {
            // Exemplo
            if (createLivro.titulo>50)
            {
                return BadRequest();
            }


            return CreateAtAction(nameof(GetById), new { id = createLivro.id }, createLivro);
        }


        // Atualizar um livro

        [HttpPut("{id}")]
        public IActionResult Put(int id ,[FromBody] UpdateLivroModel updateLivro)
        {
            // Exemplo
            if (updateLivro.descricao.lengh > 50)
            {
                return BadRequest();
            }


            return NoContent();
        }

    }
}
