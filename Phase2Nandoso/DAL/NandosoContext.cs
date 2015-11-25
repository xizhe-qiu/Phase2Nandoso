using Phase2Nandoso.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;

namespace Phase2Nandoso.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class NandosoContext : DbContext
    {

        public NandosoContext() : base("NandosoContext")
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<Reply> Replys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}