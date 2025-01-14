﻿// <auto-generated />
using System;
using EfLearning.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfLearning.Data.Migrations
{
    [DbContext(typeof(LeanTrainingContext))]
    [Migration("20250109122019_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfLearning.Models.Assemblystep", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("Cost")
                        .HasColumnType("integer")
                        .HasColumnName("cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("assemblysteps_pkey");

                    b.ToTable("assemblysteps", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Part", b =>
                {
                    b.Property<int?>("Partdefinitionid")
                        .HasColumnType("integer")
                        .HasColumnName("partdefinitionid");

                    b.Property<int?>("Productid")
                        .HasColumnType("integer")
                        .HasColumnName("productid");

                    b.HasIndex("Partdefinitionid");

                    b.HasIndex("Productid");

                    b.ToTable("parts", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Partdefinition", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<int>("Cost")
                        .HasColumnType("integer")
                        .HasColumnName("cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("partdefinitions_pkey");

                    b.ToTable("partdefinitions", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Ende")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ende");

                    b.Property<int?>("Roundid")
                        .HasColumnType("integer")
                        .HasColumnName("roundid");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start");

                    b.HasKey("Id")
                        .HasName("products_pkey");

                    b.HasIndex("Roundid");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Ende")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ende");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start");

                    b.HasKey("Id")
                        .HasName("rounds_pkey");

                    b.ToTable("rounds", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("position");

                    b.Property<int?>("Roundid")
                        .HasColumnType("integer")
                        .HasColumnName("roundid");

                    b.HasKey("Id")
                        .HasName("stations_pkey");

                    b.HasIndex("Roundid");

                    b.ToTable("stations", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Stationsassemblystep", b =>
                {
                    b.Property<int?>("Assemblystepid")
                        .HasColumnType("integer")
                        .HasColumnName("assemblystepid");

                    b.Property<int?>("Stationid")
                        .HasColumnType("integer")
                        .HasColumnName("stationid");

                    b.HasIndex("Assemblystepid");

                    b.HasIndex("Stationid");

                    b.ToTable("stationsassemblysteps", (string)null);
                });

            modelBuilder.Entity("EfLearning.Models.Part", b =>
                {
                    b.HasOne("EfLearning.Models.Partdefinition", "Partdefinition")
                        .WithMany()
                        .HasForeignKey("Partdefinitionid")
                        .HasConstraintName("parts_partdefinitionid_fkey");

                    b.HasOne("EfLearning.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Productid")
                        .HasConstraintName("parts_productid_fkey");

                    b.Navigation("Partdefinition");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EfLearning.Models.Product", b =>
                {
                    b.HasOne("EfLearning.Models.Round", "Round")
                        .WithMany("Products")
                        .HasForeignKey("Roundid")
                        .HasConstraintName("products_roundid_fkey");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("EfLearning.Models.Station", b =>
                {
                    b.HasOne("EfLearning.Models.Round", "Round")
                        .WithMany("Stations")
                        .HasForeignKey("Roundid")
                        .HasConstraintName("stations_roundid_fkey");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("EfLearning.Models.Stationsassemblystep", b =>
                {
                    b.HasOne("EfLearning.Models.Assemblystep", "Assemblystep")
                        .WithMany()
                        .HasForeignKey("Assemblystepid")
                        .HasConstraintName("stationsassemblysteps_assemblystepid_fkey");

                    b.HasOne("EfLearning.Models.Station", "Station")
                        .WithMany()
                        .HasForeignKey("Stationid")
                        .HasConstraintName("stationsassemblysteps_stationid_fkey");

                    b.Navigation("Assemblystep");

                    b.Navigation("Station");
                });

            modelBuilder.Entity("EfLearning.Models.Round", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Stations");
                });
#pragma warning restore 612, 618
        }
    }
}
