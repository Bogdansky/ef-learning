using System;
using System.Collections.Generic;
using EfLearning.Models;
using Microsoft.EntityFrameworkCore;

namespace EfLearning.DataAccess;

public partial class LeanTrainingContext : DbContext
{
    public LeanTrainingContext()
    {
    }

    public LeanTrainingContext(DbContextOptions<LeanTrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assemblystep> Assemblysteps { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<Partdefinition> Partdefinitions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Round> Rounds { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<Stationsassemblystep> Stationsassemblysteps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assemblystep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("assemblysteps_pkey");

            entity.ToTable("assemblysteps");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("parts");

            entity.Property(e => e.Partdefinitionid).HasColumnName("partdefinitionid");
            entity.Property(e => e.Productid).HasColumnName("productid");

            entity.HasOne(d => d.Partdefinition).WithMany()
                .HasForeignKey(d => d.Partdefinitionid)
                .HasConstraintName("parts_partdefinitionid_fkey");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("parts_productid_fkey");
        });

        modelBuilder.Entity<Partdefinition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partdefinitions_pkey");

            entity.ToTable("partdefinitions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ende)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ende");
            entity.Property(e => e.Roundid).HasColumnName("roundid");
            entity.Property(e => e.Start)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start");

            entity.HasOne(d => d.Round).WithMany(p => p.Products)
                .HasForeignKey(d => d.Roundid)
                .HasConstraintName("products_roundid_fkey");
        });

        modelBuilder.Entity<Round>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rounds_pkey");

            entity.ToTable("rounds");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Ende)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ende");
            entity.Property(e => e.Start)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("stations_pkey");

            entity.ToTable("stations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Position)
                .HasMaxLength(20)
                .HasColumnName("position");
            entity.Property(e => e.Roundid).HasColumnName("roundid");

            entity.HasOne(d => d.Round).WithMany(p => p.Stations)
                .HasForeignKey(d => d.Roundid)
                .HasConstraintName("stations_roundid_fkey");
        });

        modelBuilder.Entity<Stationsassemblystep>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("stationsassemblysteps");

            entity.Property(e => e.Assemblystepid).HasColumnName("assemblystepid");
            entity.Property(e => e.Stationid).HasColumnName("stationid");

            entity.HasOne(d => d.Assemblystep).WithMany()
                .HasForeignKey(d => d.Assemblystepid)
                .HasConstraintName("stationsassemblysteps_assemblystepid_fkey");

            entity.HasOne(d => d.Station).WithMany()
                .HasForeignKey(d => d.Stationid)
                .HasConstraintName("stationsassemblysteps_stationid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
