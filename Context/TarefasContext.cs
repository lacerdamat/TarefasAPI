using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TarefasAPI.Entities;

namespace TarefasAPI.Context
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options){

        }
        public DbSet<Tarefa> Tarefas {get; set; }

        
    }
}