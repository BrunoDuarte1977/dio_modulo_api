using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly Contexto _contexto;
        public ContatoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost("Create")]
        public IActionResult Create(Contato contato)
        {
            _contexto.Add(contato);
            _contexto.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _contexto.Contatos.Find(id);

            if(contato==null){
                return NotFound();
            }

            return Ok(contato);
        }
    }
}