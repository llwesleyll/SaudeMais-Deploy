using Microsoft.EntityFrameworkCore;
using SaudeMais.Models;

namespace SaudeMais.Data{
    
    public class DataContext : DbContext{

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Profissional> Profissionais {get;set;}
        public DbSet<Area> Areas {get;set;}
        public DbSet<Servico> Servicos {get;set;}
       


    }
}