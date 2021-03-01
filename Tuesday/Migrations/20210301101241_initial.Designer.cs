﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tuesday.Repositories;

namespace Tuesday.Migrations
{
    [DbContext(typeof(DbManager))]
    [Migration("20210301101241_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Tuesday.Entities.ExigenceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ExigenceType")
                        .HasColumnType("int");

                    b.Property<int?>("JalonId")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("TacheEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JalonId");

                    b.HasIndex("TacheEntityId");

                    b.ToTable("Exigence");
                });

            modelBuilder.Entity("Tuesday.Entities.JalonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AssigneeId")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("PlannedStartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("ProjetEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("ProjetEntityId");

                    b.ToTable("Jalon");
                });

            modelBuilder.Entity("Tuesday.Entities.ProjetEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Projet");
                });

            modelBuilder.Entity("Tuesday.Entities.TacheEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AssigneeId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("JalonEntityId")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("PlannedStartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RealStartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("RequiredTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("JalonEntityId");

                    b.HasIndex("RequiredTaskId");

                    b.ToTable("Tache");
                });

            modelBuilder.Entity("Tuesday.Entities.UtilisateurEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("Tuesday.Entities.ExigenceEntity", b =>
                {
                    b.HasOne("Tuesday.Entities.JalonEntity", "Jalon")
                        .WithMany()
                        .HasForeignKey("JalonId");

                    b.HasOne("Tuesday.Entities.TacheEntity", null)
                        .WithMany("Exigences")
                        .HasForeignKey("TacheEntityId");

                    b.Navigation("Jalon");
                });

            modelBuilder.Entity("Tuesday.Entities.JalonEntity", b =>
                {
                    b.HasOne("Tuesday.Entities.UtilisateurEntity", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Tuesday.Entities.ProjetEntity", null)
                        .WithMany("Jalons")
                        .HasForeignKey("ProjetEntityId");

                    b.Navigation("Assignee");
                });

            modelBuilder.Entity("Tuesday.Entities.TacheEntity", b =>
                {
                    b.HasOne("Tuesday.Entities.UtilisateurEntity", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Tuesday.Entities.JalonEntity", null)
                        .WithMany("Tasks")
                        .HasForeignKey("JalonEntityId");

                    b.HasOne("Tuesday.Entities.TacheEntity", "RequiredTask")
                        .WithMany()
                        .HasForeignKey("RequiredTaskId");

                    b.Navigation("Assignee");

                    b.Navigation("RequiredTask");
                });

            modelBuilder.Entity("Tuesday.Entities.JalonEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Tuesday.Entities.ProjetEntity", b =>
                {
                    b.Navigation("Jalons");
                });

            modelBuilder.Entity("Tuesday.Entities.TacheEntity", b =>
                {
                    b.Navigation("Exigences");
                });
#pragma warning restore 612, 618
        }
    }
}
