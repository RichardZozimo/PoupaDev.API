using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDev.API.Models;

namespace PoupaDev.API.Controllers
{
    [ApiController]
    [Route("api/ojetivos-financeiros")]
    public class ObjetivoFinanceiroController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTodos() {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id) {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(ObjetivoFinanceiroInputModel model)
        {
            return NoContent();
        }

        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, ObjetivoFinanceiroInputModel model)
        {
            return Ok();
        }
    }
}