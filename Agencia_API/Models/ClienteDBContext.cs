﻿using Microsoft.EntityFrameworkCore;

namespace Agencia_API.Models
{
    public class ClienteDBContext : DbContext
    {

        public ClienteDBContext(DbContextOptions<ClienteDBContext> options)
          : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        //public IEnumerable<Cliente> Clientes { get; internal set; }
    }
}
