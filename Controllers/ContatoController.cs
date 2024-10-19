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

        [HttpPost("Inserir")]
        public IActionResult Inserir(Contato contato)
        {
            _contexto.Add(contato);
            _contexto.SaveChanges();
            return Ok(contato);
        }

        [HttpGet("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _contexto.Contatos.Find(id);

            if(contato==null){
                return NotFound();
            }

            return Ok(contato);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            var contatos = _contexto.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpPut("Atualizar")]
        public IActionResult Atualizar(int id, Contato contato)
        {
            var contatoBanco = _contexto.Contatos.Find(id);

            if(contatoBanco==null){
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _contexto.Contatos.Update(contatoBanco);
            _contexto.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            var contatoBanco = _contexto.Contatos.Find(id);
            if(contatoBanco==null){
                return NotFound();
            }
            _contexto.Contatos.Remove(contatoBanco);
            _contexto.SaveChanges();
            return NoContent();
        }
    }
}