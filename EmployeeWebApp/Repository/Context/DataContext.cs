using EmployeeWebApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EmployeeWebApp.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("EmployeeDatabase")
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<PluralizingTableNameConvention>();
        }
    }
}