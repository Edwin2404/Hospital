using Microsoft.EntityFrameworkCore;
namespace Hospital.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Empleados> Empleados { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<SubArea> SubArea { get; set; }
        public DbSet<SubAreaxArea> SubAreaxArea{ get; set; }
        public DbSet<Direccion> Direccion { get; set; }
    }
}
