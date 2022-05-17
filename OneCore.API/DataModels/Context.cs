using Microsoft.EntityFrameworkCore;

namespace OneCore.API.DataModels
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TESTONECORE;Trusted_Connection=True;");
        //    }
        //}
    }
}
