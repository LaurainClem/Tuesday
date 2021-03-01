using Microsoft.EntityFrameworkCore;
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

        public DbSet<TacheEntity> TasksContext { get; set; }
        public DbSet<ExigenceEntity> ExigencesContext { get; set; }
        public DbSet<JalonEntity> JalonsContext { get; set; }
        public DbSet<ProjetEntity> ProjetsContext { get; set; }
        public DbSet<UtilisateurEntity> UtilisateursContext { get; set; }
    }
}
