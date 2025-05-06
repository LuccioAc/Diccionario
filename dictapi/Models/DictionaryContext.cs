using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dictapi.Models;

public partial class DictionaryContext : DbContext
{
    public DictionaryContext()
    {
    }

    public DictionaryContext(DbContextOptions<DictionaryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Incidente> Incidentes { get; set; }

    public virtual DbSet<Palabra> Palabras { get; set; }

    public virtual DbSet<Similare> Similares { get; set; }

    public virtual DbSet<Uso> Usos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LaughTop; DataBase=dictionary;Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.HasKey(e => e.Idinc).HasName("PK__Incident__047FB545F58D6B85");

            entity.Property(e => e.Idinc).HasColumnName("idinc");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Desc)
                .HasColumnType("text")
                .HasColumnName("desc");
            entity.Property(e => e.Idusr).HasColumnName("idusr");

            entity.HasOne(d => d.IdusrNavigation).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.Idusr)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Incidente__idusr__66603565");
        });

        modelBuilder.Entity<Palabra>(entity =>
        {
            entity.HasKey(e => e.Idword).HasName("PK__Palabra__89FB2F61540C4089");

            entity.ToTable("Palabra");

            entity.HasIndex(e => e.Word, "UQ__Palabra__8397405438F83F08").IsUnique();

            entity.Property(e => e.Idword).HasColumnName("idword");
            entity.Property(e => e.Meaning)
                .HasColumnType("text")
                .HasColumnName("meaning");
            entity.Property(e => e.Word)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("word");
        });

        modelBuilder.Entity<Similare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Similare__3213E83FCDC7B18F");

            entity.HasIndex(e => new { e.Idword, e.Idwsimi }, "UQ_Similares").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idword).HasColumnName("idword");
            entity.Property(e => e.Idwsimi).HasColumnName("idwsimi");

            entity.HasOne(d => d.IdwordNavigation).WithMany(p => p.SimilareIdwordNavigations)
                .HasForeignKey(d => d.Idword)
                .HasConstraintName("FK__Similares__idwor__5CD6CB2B");

            entity.HasOne(d => d.IdwsimiNavigation).WithMany(p => p.SimilareIdwsimiNavigations)
                .HasForeignKey(d => d.Idwsimi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Similares__idwsi__5DCAEF64");
        });

        modelBuilder.Entity<Uso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usos__3213E83FFD1CA857");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Desc)
                .HasColumnType("text")
                .HasColumnName("desc");
            entity.Property(e => e.Idword).HasColumnName("idword");

            entity.HasOne(d => d.IdwordNavigation).WithMany(p => p.Usos)
                .HasForeignKey(d => d.Idword)
                .HasConstraintName("FK__Usos__idword__59063A47");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusr).HasName("PK__Usuario__250C90F68023A64A");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Codeusr, "UQ__Usuario__430A91805ECEE593").IsUnique();

            entity.Property(e => e.Idusr).HasColumnName("idusr");
            entity.Property(e => e.Codeusr)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("codeusr");
            entity.Property(e => e.Nameusr)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nameusr");
            entity.Property(e => e.Passw)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passw");
            entity.Property(e => e.Rol).HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
