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
    }
}
