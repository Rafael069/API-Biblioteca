using Biblioteca.Application.InputModels;
using Biblioteca.Application.Services;
using Biblioteca.Application.Services.Implementations;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/emprestimo")]
    public class EmprestimoController : ControllerBase
    {
        
        private readonly IEmprestimoService _emprestimoService;

        // Buscar todo os livros

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var emprestimos = _emprestimoService.GetAll();
            return Ok(emprestimos);
        }

        // Buscar um Emprestimo

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emprestimos = _emprestimoService.GetById(id);

            if (emprestimos == null)
            {
                return NotFound();
            }

            return Ok(emprestimos);
        }






        [HttpPost]
        public IActionResult Post([FromBody] NewEmprestimoInputModel inputModel)
        {
            // Exemplo
            if (inputModel == null || inputModel.DataDevolucao <= inputModel.DataEmprestimo)
            {
                return BadRequest("Dados inválidos para empréstimo.");
            }

            //var id = _emprestimoService.Create(inputModel);

            //return Ok();
            var id = _emprestimoService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

            //return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);

        }

        [HttpPut("returnBook")]
        public IActionResult ReturnBook([FromBody] UpdateEmprestimoInputModel inputModel)
        {
            try
            {
                //_emprestimoService.Update(inputModel);
                //var status = _emprestimoService.VerificarStatusDevolucao(id);
                //var status = _emprestimoService.GetStatusDevolucao(inputModel.Id);
                var status = _emprestimoService.GetStatusDevolucao(inputModel);
                //var status = "OK";
                return Ok(new { Mensagem = status });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
