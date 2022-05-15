using Microsoft.EntityFrameworkCore;

namespace Reprograma.Data
{
    public class Contexto: DbContext
    {
            public Contexto(DbContextOptions<Contexto> options) : base(options)  { }
            public DbSet<Usuario> Usuarios { get; set; }

    }
}
