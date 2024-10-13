﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RpgMenager.Infrastructure.Persistence;

#nullable disable

namespace RpgMenager.Infrastructure.Migrations
{
    [DbContext(typeof(RpgMenagerDbContext))]
    partial class RpgMenagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RpgMenager.Domain.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("EncodedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasDiscriminator().HasValue("Character");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int?>("Charges")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncodedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncodedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncodedName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfTheList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathToImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("statisticsEnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.NPC", b =>
                {
                    b.HasBaseType("RpgMenager.Domain.Entities.Character");

                    b.Property<string>("AttitudeToAnotherCharacter")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("NPC");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.PC", b =>
                {
                    b.HasBaseType("RpgMenager.Domain.Entities.Character");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.HasIndex("PlayerId");

                    b.HasDiscriminator().HasValue("PC");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Item", b =>
                {
                    b.HasOne("RpgMenager.Domain.Entities.Character", "Character")
                        .WithMany("ListOfItems")
                        .HasForeignKey("CharacterId");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Statistic", b =>
                {
                    b.HasOne("RpgMenager.Domain.Entities.Character", "Character")
                        .WithMany("HasListOfList")
                        .HasForeignKey("CharacterId");

                    b.Navigation("Character");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.PC", b =>
                {
                    b.HasOne("RpgMenager.Domain.Entities.Player", "Player")
                        .WithMany("PlayerCharacters")
                        .HasForeignKey("PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Character", b =>
                {
                    b.Navigation("ListOfItems");

                    b.Navigation("HasListOfList");
                });

            modelBuilder.Entity("RpgMenager.Domain.Entities.Player", b =>
                {
                    b.Navigation("PlayerCharacters");
                });
#pragma warning restore 612, 618
        }
    }
}
