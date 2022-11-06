using Microsoft.EntityFrameworkCore;

namespace Agencia_Viagens.Models
{
    public class ClienteDBContext : DbContext
    {
        public ClienteDBContext(DbContextOptions<ClienteDBContext> options)
          : base(options)
        { }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
