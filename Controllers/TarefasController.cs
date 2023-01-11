using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TarefasAPI.Context;
using TarefasAPI.Entities;

namespace TarefasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TarefasContext _context;

        public TarefasController(TarefasContext context){
            _context = context;

        }

        [HttpGet]
        public IActionResult ObterTodasAsTarefas(){
            var tarefas = _context.Tarefas;
            return Ok(tarefas);
        }

        [HttpGet("ObterPorId/{id}")]
        public IActionResult ObterAsTarefasPorId(int id){
            var tarefa = _context.Tarefas.Find(id);
            if (tarefa == null){
                return NotFound();
                        }
            return Ok(tarefa);
        }


        [HttpGet("ObterPorTitulo/{titulo}")]
        public IActionResult ObterAsTarefasPorTitulo(string titulo){
            var tarefa = _context.Tarefas.Where(x=> x.Titulo.Contains(titulo));
            if (tarefa == null){
                return NotFound();
                        }
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult CriarTarefa(Tarefa tarefa){
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);

        }
        
        [HttpDelete("DeletarPorId")]
        public IActionResult CriarTarefa(int id){
           var tarefa= _context.Tarefas.Find(id);
           if(tarefa == null){
            return NotFound();
           }
           _context.Tarefas.Remove(tarefa);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("ModificarPorId")]
        public IActionResult ModificarTarefa(int id, Tarefa tarefa){
            if (_context.Tarefas.Find(id) != null){
                var tarefaBanco = _context.Tarefas.Find(id);
                tarefaBanco.Titulo = tarefa.Titulo;
                tarefaBanco.Descricao = tarefa.Descricao;
                tarefaBanco.Data = tarefa.Data;
                tarefaBanco.Status = tarefa.Status;
                _context.SaveChanges();
                return Ok(tarefa);
            }
            return NotFound();

        }
        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(StatusTarefas status){
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }       
        [HttpGet("ObterPorData")]
        public IActionResult ObterPorStatus(DateTime data){
            var tarefa = _context.Tarefas.Where(x => x.Data == data);
            return Ok(tarefa);
        }   

        
    }
}