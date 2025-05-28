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

    public virtual DbSet<Antonimo> Antonimos { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<Palabra> Palabras { get; set; }

    public virtual DbSet<Similar> Similars { get; set; }

    public virtual DbSet<Sinonimo> Sinonimos { get; set; }

    public virtual DbSet<Uso> Usos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Name=DBConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Antonimo>(entity =>
        {
            entity.HasKey(e => e.Idant).HasName("PK__Antonimo__06CF9BBD0F9E3FF3");

            entity.ToTable("Antonimo");

            entity.HasIndex(e => e.Idantwrd, "IX_Antonimo_idantwrd");

            entity.HasIndex(e => e.Idantwrd2, "IX_Antonimo_idantwrd2");

            entity.HasIndex(e => new { e.Idantwrd, e.Idantwrd2 }, "UQ_Antonimo").IsUnique();

            entity.Property(e => e.Idant).HasColumnName("idant");
            entity.Property(e => e.Idantwrd).HasColumnName("idantwrd");
            entity.Property(e => e.Idantwrd2).HasColumnName("idantwrd2");

            entity.HasOne(d => d.IdantwrdNavigation).WithMany(p => p.AntonimoIdantwrdNavigations)
                .HasForeignKey(d => d.Idantwrd)
                .HasConstraintName("FK__Antonimo__idantw__440B1D61");

            entity.HasOne(d => d.Idantwrd2Navigation).WithMany(p => p.AntonimoIdantwrd2Navigations)
                .HasForeignKey(d => d.Idantwrd2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Antonimo__idantw__44FF419A");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Idinc).HasName("PK__Incident__047FB5457B0F3F7C");

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
                .HasConstraintName("FK__Incident__idusr__534D60F1");
        });

        modelBuilder.Entity<Palabra>(entity =>
        {
            entity.HasKey(e => e.Idword).HasName("PK__Palabra__89FB2F61A1FD6A6A");

            entity.ToTable("Palabra");

            entity.HasIndex(e => e.Word, "IX_Palabra_word");

            entity.HasIndex(e => e.Word, "UQ__Palabra__839740541A220752").IsUnique();

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
            entity.HasKey(e => e.Idsim).HasName("PK__Similar__258726DFC22EFAAB");

            entity.ToTable("Similar");

            entity.HasIndex(e => e.Idsimwrd, "IX_Similar_idsimwrd");

            entity.HasIndex(e => e.Idsimwrd2, "IX_Similar_idsimwrd2");

            entity.HasIndex(e => new { e.Idsimwrd, e.Idsimwrd2 }, "UQ_Similares").IsUnique();

            entity.Property(e => e.Idsim).HasColumnName("idsim");
            entity.Property(e => e.Idsimwrd).HasColumnName("idsimwrd");
            entity.Property(e => e.Idsimwrd2).HasColumnName("idsimwrd2");

            entity.HasOne(d => d.IdsimwrdNavigation).WithMany(p => p.SimilarIdsimwrdNavigations)
                .HasForeignKey(d => d.Idsimwrd)
                .HasConstraintName("FK__Similar__idsimwr__49C3F6B7");

            entity.HasOne(d => d.Idsimwrd2Navigation).WithMany(p => p.SimilarIdsimwrd2Navigations)
                .HasForeignKey(d => d.Idsimwrd2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Similar__idsimwr__4AB81AF0");
        });

        modelBuilder.Entity<Sinonimo>(entity =>
        {
            entity.HasKey(e => e.Idsin).HasName("PK__Sinonimo__258726DED0419211");

            entity.ToTable("Sinonimo");

            entity.HasIndex(e => e.Idsinwrd, "IX_Sinonimo_idsinwrd");

            entity.HasIndex(e => e.Idsinwrd2, "IX_Sinonimo_idsinwrd2");

            entity.HasIndex(e => new { e.Idsinwrd, e.Idsinwrd2 }, "UQ_Sinonimo").IsUnique();

            entity.Property(e => e.Idsin).HasColumnName("idsin");
            entity.Property(e => e.Idsinwrd).HasColumnName("idsinwrd");
            entity.Property(e => e.Idsinwrd2).HasColumnName("idsinwrd2");

            entity.HasOne(d => d.IdsinwrdNavigation).WithMany(p => p.SinonimoIdsinwrdNavigations)
                .HasForeignKey(d => d.Idsinwrd)
                .HasConstraintName("FK__Sinonimo__idsinw__3E52440B");

            entity.HasOne(d => d.Idsinwrd2Navigation).WithMany(p => p.SinonimoIdsinwrd2Navigations)
                .HasForeignKey(d => d.Idsinwrd2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sinonimo__idsinw__3F466844");
        });

        modelBuilder.Entity<Uso>(entity =>
        {
            entity.HasKey(e => e.Iduse).HasName("PK__Uso__250C90E514390F1D");

            entity.ToTable("Uso");

            entity.Property(e => e.Iduse).HasColumnName("iduse");
            entity.Property(e => e.Descrip)
                .HasColumnType("text")
                .HasColumnName("descrip");
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
            entity.HasKey(e => e.Idusr).HasName("PK__Usuario__250C90F6F1050338");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Codeusr, "UQ__Usuario__430A918044AD2245").IsUnique();

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
