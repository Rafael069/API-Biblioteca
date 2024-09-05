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

        //private readonly IEmprestimoService _emprestimoService;
        private readonly IMediator _mediator;

        // Buscar todo os livros

        public EmprestimoController(/*IEmprestimoService emprestimoService, */IMediator mediator)
        {
            //_emprestimoService = emprestimoService;
            _mediator = mediator;
        }


        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var emprestimos = _emprestimoService.GetAll();
        //    return Ok(emprestimos);
        //}



        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEmprestimosQuery();

            var emprestimos = await _mediator.Send(query);

            return Ok(emprestimos);
        }

        // Buscar um Emprestimo

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var emprestimos = _emprestimoService.GetById(id);

        //    if (emprestimos == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(emprestimos);
        //}

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



        //[HttpPost]
        //public IActionResult Post([FromBody] NewEmprestimoInputModel inputModel)
        //{
        //    // Exemplo
        //    if (inputModel == null || inputModel.DataDevolucao <= inputModel.DataEmprestimo)
        //    {
        //        return BadRequest("Dados inválidos para empréstimo.");
        //    }

        //    var id = _emprestimoService.Create(inputModel);
        //    return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        //}



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

        //[HttpPut("returnBook")]
        //public IActionResult ReturnBook([FromBody] UpdateEmprestimoInputModel inputModel)
        //{
        //    try
        //    {

        //        var status = _emprestimoService.Devolver(inputModel);
        //        return Ok(new { Mensagem = status });
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}


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
