﻿// <auto-generated />
using System;
using LeagueApp_xamarin_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeagueApp_xamarin_backend.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .IsUnique();

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LeagueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxTeamCapacity")
                        .HasColumnType("int");

                    b.Property<int>("MaxTeams")
                        .HasColumnType("int");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationEndDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("RegistrationFee")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime>("RegistrationStartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("SportType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("Leagues", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<int>("TeamLeaderId")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("TeamLeaderId");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserID");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.BasketballLeague", b =>
                {
                    b.HasBaseType("LeagueApp_xamarin_backend.Models.League");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.ToTable("BasketballLeagues", (string)null);
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.NicheLeague", b =>
                {
                    b.HasBaseType("LeagueApp_xamarin_backend.Models.League");

                    b.Property<int>("NichePoints")
                        .HasColumnType("int");

                    b.ToTable("NicheLeagues", (string)null);
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.SoccerLeague", b =>
                {
                    b.HasBaseType("LeagueApp_xamarin_backend.Models.League");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.ToTable("SoccerLeagues", (string)null);
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.League", b =>
                {
                    b.HasOne("LeagueApp_xamarin_backend.Models.User", null)
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.Team", b =>
                {
                    b.HasOne("LeagueApp_xamarin_backend.Models.League", null)
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueApp_xamarin_backend.Models.User", "TeamLeader")
                        .WithMany()
                        .HasForeignKey("TeamLeaderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TeamLeader");
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.User", b =>
                {
                    b.HasOne("LeagueApp_xamarin_backend.Models.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.BasketballLeague", b =>
                {
                    b.HasOne("LeagueApp_xamarin_backend.Models.League", null)
                        .WithOne()
                        .HasForeignKey("LeagueApp_xamarin_backend.Models.BasketballLeague", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.NicheLeague", b =>
                {
                    b.HasOne("LeagueApp_xamarin_backend.Models.League", null)
                        .WithOne()
                        .HasForeignKey("LeagueApp_xamarin_backend.Models.NicheLeague", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.SoccerLeague", b =>
                {
                    b.HasOne("LeagueApp_xamarin_backend.Models.League", null)
                        .WithOne()
                        .HasForeignKey("LeagueApp_xamarin_backend.Models.SoccerLeague", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("LeagueApp_xamarin_backend.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
