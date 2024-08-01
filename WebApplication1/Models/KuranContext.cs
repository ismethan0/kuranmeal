using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace kuranmealuygulaması.Models;

public partial class KuranContext : DbContext
{
    public KuranContext()
    {
    }

    public KuranContext(DbContextOptions<KuranContext> options)
        : base(options)
    {
        
    }

    public virtual DbSet<AnadoluTurkcesi> AnadoluTurkcesis { get; set; }

    public virtual DbSet<Anonim> Anonims { get; set; }

    public virtual DbSet<Arapca> Arapcas { get; set; }

    public virtual DbSet<AzeriTurkcesi> AzeriTurkcesis { get; set; }

    public virtual DbSet<DiyanetEski> DiyanetEskis { get; set; }

    public virtual DbSet<DiyanetYeni> DiyanetYenis { get; set; }

    public virtual DbSet<Edipyuksel> Edipyuksels { get; set; }

    public virtual DbSet<ElmaliHamdi> ElmaliHamdis { get; set; }

    public virtual DbSet<ElmaliHamdiOrginal> ElmaliHamdiOrginals { get; set; }

    public virtual DbSet<Esed> Eseds { get; set; }

    public virtual DbSet<Mealler> Meallers { get; set; }

    public virtual DbSet<Suleymaniye> Suleymaniyes { get; set; }

    public virtual DbSet<SureTable> SureTables { get; set; }

    public virtual DbSet<YasarNuriInısAyetler> YasarNuriInısAyetlers { get; set; }

    public virtual DbSet<Yusufali> Yusufalis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NHVLICF\\DATABASEONE;Database=kuran;Trusted_Connection=True;TrustServerCertificate=true;");
           
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnadoluTurkcesi>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("AnadoluTurkcesi");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.AnadoluTurkcesis)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AnadoluTurkcesi_Sure_Table");
        });

        modelBuilder.Entity<Anonim>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("Anonim");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.Anonims)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Anonim_Sure_Table");
        });

        modelBuilder.Entity<Arapca>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("arapca");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.Arapcas)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_arapca_Sure_Table");
        });

        modelBuilder.Entity<AzeriTurkcesi>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("AzeriTurkcesi");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.AzeriTurkcesis)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AzeriTurkcesi_Sure_Table");
        });

        modelBuilder.Entity<DiyanetEski>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("DiyanetEski");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.DiyanetEskis)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiyanetEski_Sure_Table");
        });

        modelBuilder.Entity<DiyanetYeni>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("DiyanetYeni");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.DiyanetYenis)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DiyanetYeni_Sure_Table");
        });

        modelBuilder.Entity<Edipyuksel>(entity =>
        {
            entity.HasKey(e => e.Index).HasName("PK_edipguncell");

            entity.ToTable("edipyuksel");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.Edipyuksels)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_edipyuksel_Sure_Table");
        });

        modelBuilder.Entity<ElmaliHamdi>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("ElmaliHamdi");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.ElmaliHamdis)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElmaliHamdi_Sure_Table");
        });

        modelBuilder.Entity<ElmaliHamdiOrginal>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("ElmaliHamdiOrginal");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.ElmaliHamdiOrginals)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ElmaliHamdiOrginal_Sure_Table");
        });

        modelBuilder.Entity<Esed>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("Esed");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.Eseds)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Esed_Sure_Table");
        });

        modelBuilder.Entity<Mealler>(entity =>
        {
            entity.HasKey(e => e.MealId);

            entity.ToTable("Mealler");

            entity.Property(e => e.MealId).ValueGeneratedNever();
            entity.Property(e => e.CevirmenHakinda).HasColumnName("Cevirmen_Hakinda");
            entity.Property(e => e.Cevrimen).HasMaxLength(100);
            entity.Property(e => e.Meal).HasMaxLength(300);
            entity.Property(e => e.Resmi).HasMaxLength(300);
        });

        modelBuilder.Entity<Suleymaniye>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("Suleymaniye");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.Suleymaniyes)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Suleymaniye_Sure_Table1");
        });

        modelBuilder.Entity<SureTable>(entity =>
        {
            entity.HasKey(e => e.SureId);

            entity.ToTable("Sure_Table");

            entity.Property(e => e.SureId).ValueGeneratedNever();
            entity.Property(e => e.NuzulSirasi).HasMaxLength(200);
            entity.Property(e => e.Sureler).HasMaxLength(250);
        });

        modelBuilder.Entity<YasarNuriInısAyetler>(entity =>
        {
            entity.HasKey(e => e.Index);

            entity.ToTable("Yasar_Nuri_Inıs_Ayetler");

            entity.Property(e => e.Index).ValueGeneratedNever();
            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany(p => p.YasarNuriInısAyetlers)
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yasar_Nuri_Inıs_Ayetler_Sure_Table");
        });

        modelBuilder.Entity<Yusufali>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("yusufali");

            entity.Property(e => e.Ayet).HasMaxLength(2000);

            entity.HasOne(d => d.Sure).WithMany()
                .HasForeignKey(d => d.SureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_yusufali_Sure_Table");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
