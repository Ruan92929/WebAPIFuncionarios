using Microsoft.EntityFrameworkCore;
using ProjetoWebAPI.Models;

namespace ProjetoWebAPI.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base (options)
        { }

       public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }

}
