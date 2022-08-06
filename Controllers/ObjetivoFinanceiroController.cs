using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDev.API.Entities;
using PoupaDev.API.Models;
using PoupaDev.API.Percistence;

namespace PoupaDev.API.Controllers
{
    [ApiController]
    [Route("api/ojetivos-financeiros")]
    public class ObjetivoFinanceiroController : ControllerBase
    {
        private readonly PoupaDevContext _context;

        public ObjetivoFinanceiroController(PoupaDevContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTodos() {
            var objetivos = _context.Objetivos;

            return Ok(objetivos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var objetivo = _context.Objetivos.SingleOrDefault(o => o.Id == id);

            if (objetivo == null)
                return NotFound();

            return Ok(objetivo);
        }

        [HttpPost]
        public IActionResult Post(ObjetivoFinanceiroInputModel model)
        {
            var objetivo = new ObjetivoFinanceiro(
                model.Titulo, 
                model.Descricao, 
                model.ValorObjetivo);

            _context.Objetivos.Add(objetivo);
            
            var id = objetivo.Id;

            return CreatedAtAction(
                "GetById",
                new { id = id },
                model
            );
        }

        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, OperacaoInputModel model)
        {
            var operacao = new Operacao(model.Valor, model.TipoOperacao);

            var objetivo = _context.Objetivos.SingleOrDefault(o => o.Id == id);

            if (objetivo == null) 
                return NotFound();

            objetivo.RealizarOperacaoFinanceira(operacao);

            return NoContent();
        }
    }
}