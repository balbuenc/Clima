namespace ClimaAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClimaEF : DbContext
    {
        public ClimaEF()
            : base("name=ClimaEF")
        {
        }

        public virtual DbSet<Afirmaciones> Afirmaciones { get; set; }
        public virtual DbSet<AsignacionesEmpresas> AsignacionesEmpresas { get; set; }
        public virtual DbSet<Dimensiones> Dimensiones { get; set; }
        public virtual DbSet<EncuestaPreguntas> EncuestaPreguntas { get; set; }
        public virtual DbSet<Encuestas> Encuestas { get; set; }
        public virtual DbSet<EvaluacionAfirmaciones> EvaluacionAfirmaciones { get; set; }
        public virtual DbSet<Periodos> Periodos { get; set; }
        public virtual DbSet<TipoPreguntas> TipoPreguntas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afirmaciones>()
                .Property(e => e.Enunciado)
                .IsUnicode(false);

            modelBuilder.Entity<Afirmaciones>()
                .HasMany(e => e.EncuestaPreguntas)
                .WithRequired(e => e.Afirmaciones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dimensiones>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Dimensiones>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Dimensiones>()
                .HasMany(e => e.EncuestaPreguntas)
                .WithRequired(e => e.Dimensiones)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Encuestas>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Encuestas>()
                .HasMany(e => e.AsignacionesEmpresas)
                .WithRequired(e => e.Encuestas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Encuestas>()
                .HasMany(e => e.EncuestaPreguntas)
                .WithRequired(e => e.Encuestas)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EvaluacionAfirmaciones>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Periodos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Periodos>()
                .HasMany(e => e.Encuestas)
                .WithRequired(e => e.Periodos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPreguntas>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPreguntas>()
                .HasMany(e => e.EncuestaPreguntas)
                .WithRequired(e => e.TipoPreguntas)
                .WillCascadeOnDelete(false);
        }
    }
}
