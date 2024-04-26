using ApiSeguridadCubos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSeguridadCubos.Data
{
    public class CubosContext: DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options)
            : base(options)
        {

        }

        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cubo> Cubos { get; set; }
    }
}
