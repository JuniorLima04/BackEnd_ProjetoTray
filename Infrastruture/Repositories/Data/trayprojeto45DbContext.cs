using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastruture.Repositories.Data
{
    public partial class trayprojeto45DbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Compra> Compras { get; set; }

        public trayprojeto45DbContext(DbContextOptions<trayprojeto45DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            // Configurações para a entidade Pessoa
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(p => p.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(p => p.Senha)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(p => p.Email)
                    .IsUnique();
            });

            // Configurações para a entidade Compra
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(c => c.Produto)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(c => c.Cidade)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Estado)
                    .HasMaxLength(50);

                entity.Property(c => c.Complemento)
                    .HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}