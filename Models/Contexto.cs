using Microsoft.EntityFrameworkCore;

namespace ProjetoFinal.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<ItemCompra> ItemCompras { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<FechamentoCaixa> Caixas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //Relação Compra - Cliente
            modelBuilder.Entity<Compra>()
                        .HasOne(cr => cr.Cliente)
                        .WithMany(c => c.Compras)
                        .HasPrincipalKey(c => c.ClienteID)
                        .HasForeignKey(cr => cr.ClienteID)
                        .OnDelete(DeleteBehavior.Restrict);

            //Aqui eu digo que o CPF é único, ou seja, não tem como cadastrar 2 CPF's iguais.
            modelBuilder.Entity<Cliente>()
                        .HasIndex(c => c.CPF)
                        .IsUnique();

            base.OnModelCreating(modelBuilder);
        }

    }
   
}
