using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace autonoma3Tiempo.Models
{
    public class temperatura
    {
        [Key]
        public int id_temperatura { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string fecha { get; set; }
        public int temperatura_max { get; set; }
        public int temperatura_min { get; set; }
        public string hora { get; set; }
    }
    public class TemperaturaDbContext : DbContext
    {
        public TemperaturaDbContext(DbContextOptions<TemperaturaDbContext> options) : base(options)
        {
        }

        public DbSet<temperatura> temperatura { get; set; }
    }
}
