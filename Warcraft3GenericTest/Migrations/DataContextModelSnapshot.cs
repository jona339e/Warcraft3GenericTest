﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Warcraft3GenericTest.Data;

#nullable disable

namespace Warcraft3GenericTest.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FactionRace", b =>
                {
                    b.Property<int>("FactionsId")
                        .HasColumnType("int");

                    b.Property<int>("RacesId")
                        .HasColumnType("int");

                    b.HasKey("FactionsId", "RacesId");

                    b.HasIndex("RacesId");

                    b.ToTable("RaceFactions", (string)null);
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodCost")
                        .HasColumnType("int");

                    b.Property<int>("GoldCost")
                        .HasColumnType("int");

                    b.Property<int>("LumberCost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("RaceId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("FactionRace", b =>
                {
                    b.HasOne("Warcraft3GenericTest.Models.Faction", null)
                        .WithMany()
                        .HasForeignKey("FactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Warcraft3GenericTest.Models.Race", null)
                        .WithMany()
                        .HasForeignKey("RacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Building", b =>
                {
                    b.HasOne("Warcraft3GenericTest.Models.Race", "Race")
                        .WithMany("Buildings")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Unit", b =>
                {
                    b.HasOne("Warcraft3GenericTest.Models.Building", "Building")
                        .WithMany("Units")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Warcraft3GenericTest.Models.Race", "Race")
                        .WithMany("Units")
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("Race");
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Building", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("Warcraft3GenericTest.Models.Race", b =>
                {
                    b.Navigation("Buildings");

                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}
