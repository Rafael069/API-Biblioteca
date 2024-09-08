using Biblioteca.Application.Commands.Emprestimos.CreateEmprestimo;
using Biblioteca.Application.Commands.Emprestimos.UpdateDevolver;
using Biblioteca.Application.Queries.Emprestimos.GetAllEmprestimos;
//using Biblioteca.Application.Queries.Livros.GetAllLivros;
using Biblioteca.Application.Queries.Emprestimos.GetByEmprestimo;
//using Biblioteca.Application.Queries.Livros.GetByIdLivro;
//using Biblioteca.Application.Services;

//using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/emprestimo")]
    public class EmprestimoController : ControllerBase
    {

        private readonly IMediator _mediator;


        public EmprestimoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // Buscar todo os Emprestimos

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEmprestimosQuery();

            var emprestimos = await _mediator.Send(query);

            return Ok(emprestimos);
        }


        // Buscar um Emprestimo

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var getByIdEmprestimoQuery = new GetByIdEmprestimoQuery(id);

                var emprestimos = await _mediator.Send(getByIdEmprestimoQuery);

                return Ok(emprestimos);
            }
            catch (EmprestimoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.");
            }


        }

        // Criar um Emprestimo

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEmprestimoCommand command)
        {
            // Exemplo
            if (command == null || command.DataDevolucao <= command.DataEmprestimo)
            {
                return BadRequest("Dados inválidos para empréstimo.");
            }

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = id }, command);

        }




        // Retorma o Livro e atualiza o status do  Emprestimo

        [HttpPut("returnBook")]
        public async Task<IActionResult> ReturnBook([FromBody] UpdateDevolverCommand command)
        {
            try
            {

                // Envia o comando e obtém o resultado
                var result = await _mediator.Send(command);

                // Retorna o resultado como uma resposta OK
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
