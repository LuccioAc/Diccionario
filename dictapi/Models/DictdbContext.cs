using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dictapi.Models;

public partial class DictdbContext : DbContext
{
    public DictdbContext()
    {
    }

    public DictdbContext(DbContextOptions<DictdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<Palabra> Palabras { get; set; }

    public virtual DbSet<Similar> Similars { get; set; }

    public virtual DbSet<Uso> Usos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LaughTop; DataBase=dictdb;Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Idinc).HasName("PK__Incident__047FB5455AE87FD1");

            entity.ToTable("Incident");

            entity.Property(e => e.Idinc).HasColumnName("idinc");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Descrip)
                .HasColumnType("text")
                .HasColumnName("descrip");
            entity.Property(e => e.Idusr).HasColumnName("idusr");

            entity.HasOne(d => d.IdusrNavigation).WithMany(p => p.Incidents)
                .HasForeignKey(d => d.Idusr)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Incident__idusr__47DBAE45");
        });

        modelBuilder.Entity<Palabra>(entity =>
        {
            entity.HasKey(e => e.Idword).HasName("PK__Palabra__89FB2F610EE6B522");

            entity.ToTable("Palabra");

            entity.HasIndex(e => e.Word, "UQ__Palabra__8397405480FFC62F").IsUnique();

            entity.Property(e => e.Idword).HasColumnName("idword");
            entity.Property(e => e.Meaning)
                .HasColumnType("text")
                .HasColumnName("meaning");
            entity.Property(e => e.Word)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("word");
        });

        modelBuilder.Entity<Similar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Similar__3213E83FE2264F7E");

            entity.ToTable("Similar");

            entity.HasIndex(e => new { e.Idword, e.Idwsimi }, "UQ_Similares").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idword).HasColumnName("idword");
            entity.Property(e => e.Idwsimi).HasColumnName("idwsimi");

            entity.HasOne(d => d.IdwordNavigation).WithMany(p => p.SimilarIdwordNavigations)
                .HasForeignKey(d => d.Idword)
                .HasConstraintName("FK__Similar__idword__3E52440B");

            entity.HasOne(d => d.IdwsimiNavigation).WithMany(p => p.SimilarIdwsimiNavigations)
                .HasForeignKey(d => d.Idwsimi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Similar__idwsimi__3F466844");
        });

        modelBuilder.Entity<Uso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Uso__3213E83FE78DE145");

            entity.ToTable("Uso");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descrp)
                .HasColumnType("text")
                .HasColumnName("descrp");
            entity.Property(e => e.Idword).HasColumnName("idword");
            entity.Property(e => e.Wuse)
                .HasColumnType("text")
                .HasColumnName("wuse");

            entity.HasOne(d => d.IdwordNavigation).WithMany(p => p.Usos)
                .HasForeignKey(d => d.Idword)
                .HasConstraintName("FK__Uso__idword__3A81B327");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusr).HasName("PK__Usuario__250C90F6A4BDBAC7");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Codeusr, "UQ__Usuario__430A918060CA69EE").IsUnique();

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
