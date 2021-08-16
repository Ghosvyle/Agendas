using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace backend.Models
{
    public partial class LUCKYContext : DbContext
    {
        public LUCKYContext()
        {
        }

        public LUCKYContext(DbContextOptions<LUCKYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.ToTable("Contacto");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("numero");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
