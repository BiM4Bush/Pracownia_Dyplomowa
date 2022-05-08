﻿// <auto-generated />
using System;
using FutStats.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FutStats.Infrastructure.Database.Migrations
{
    [DbContext(typeof(FutStatDbContext))]
    [Migration("20220507232839_UpdateTeam")]
    partial class UpdateTeam
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FutStats.Domain.Entities.CoachEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Nationality")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique()
                        .HasFilter("[TeamId] IS NOT NULL");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("KitNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<Guid?>("StatisticEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StatisticEntityId");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.StatisticEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId")
                        .IsUnique()
                        .HasFilter("[PlayerId] IS NOT NULL");

                    b.ToTable("Statistic");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CoachId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.CoachEntity", b =>
                {
                    b.HasOne("FutStats.Domain.Entities.TeamEntity", "Team")
                        .WithOne()
                        .HasForeignKey("FutStats.Domain.Entities.CoachEntity", "TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.PlayerEntity", b =>
                {
                    b.HasOne("FutStats.Domain.Entities.StatisticEntity", "StatisticEntity")
                        .WithMany()
                        .HasForeignKey("StatisticEntityId");

                    b.HasOne("FutStats.Domain.Entities.TeamEntity", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("StatisticEntity");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.StatisticEntity", b =>
                {
                    b.HasOne("FutStats.Domain.Entities.PlayerEntity", "Player")
                        .WithOne()
                        .HasForeignKey("FutStats.Domain.Entities.StatisticEntity", "PlayerId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.TeamEntity", b =>
                {
                    b.HasOne("FutStats.Domain.Entities.CoachEntity", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachId");

                    b.Navigation("Coach");
                });

            modelBuilder.Entity("FutStats.Domain.Entities.TeamEntity", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
