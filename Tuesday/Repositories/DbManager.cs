﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Repositories
{
    public class DbManager : DbContext
    {
        public DbManager(DbContextOptions<DbManager> options): base(options) { }

        public DbSet<TaskEntity> TasksContext { get; set; }
        public DbSet<ExigenceEntity> ExigencesContext { get; set; }
        public DbSet<JalonEntity> JalonsContext { get; set; }
        public DbSet<ProjectEntity> ProjetsContext { get; set; }
        public DbSet<UserEntity> UtilisateursContext { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JalonEntity>()
                .HasOne<ProjectEntity>()
                .WithMany()
                .HasForeignKey(jalon => jalon.ProjectId);

            modelBuilder.Entity<ExigenceEntity>()
                .HasOne<ProjectEntity>()
                .WithMany()
                .HasForeignKey(exigence => exigence.ProjectId);

            modelBuilder.Entity<ExigenceEntity>()
                .HasOne<JalonEntity>()
                .WithMany()
                .HasForeignKey(exigence => exigence.JalonID);

            modelBuilder.Entity<JalonEntity>()
                .HasOne<UserEntity>()
                .WithMany()
                .HasForeignKey(jalon => jalon.AssigneeId);

            modelBuilder.Entity<TaskEntity>()
                .HasOne<UserEntity>()
                .WithMany()
                .HasForeignKey(task => task.AssigneeId);
            /*
            modelBuilder.Entity<TaskExigence>()
                .HasKey(taskEntity => new { taskEntity.TaskId, taskEntity.ExigenceId });
            modelBuilder.Entity<TaskExigence>()
                .HasOne(taskEntity => taskEntity.Task)
                .WithMany(task => task.TaskExigences)
                .HasForeignKey(taskEntity => taskEntity.TaskId);
            modelBuilder.Entity<TaskExigence>()
                .HasOne(taskEntity => taskEntity.Exigence)
                .WithMany(task => task.TaskExigences)
                .HasForeignKey(taskEntity => taskEntity.ExigenceId); */
        }
    }
}
