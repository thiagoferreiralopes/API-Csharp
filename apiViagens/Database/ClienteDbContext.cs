using Microsoft.EntityFrameworkCore;
using apiViagens.Model;

namespace apiViagens.Database
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext>
        options) : base(options){

        }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            var cliente = modelBuilder.Entity<Cliente>();
            cliente.ToTable("cliente");
            cliente.HasKey(x => x.Id);
            cliente.Property(x => x.Id).HasColumnName("id_Cliente").ValueGeneratedOnAdd();
            cliente.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            cliente.Property(x => x.Email).HasColumnName("email");
            cliente.Property(x => x.Senha_Cliente).HasColumnName("senha_cliente").IsRequired();
        }

    }

}

