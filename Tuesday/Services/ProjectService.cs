using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tuesday.Entities;

namespace Tuesday.Services
{
    public class ProjectService : IProjectService
    {
        List<ProjectEntity> projects = new List<ProjectEntity>();

        public List<ProjectEntity> FindAll()
        {
            projects.Add(new ProjectEntity("Projet 1"));
            projects.Add(new ProjectEntity("Projet 2"));
            projects.Add(new ProjectEntity("Projet 3"));
            return projects;
        }

        public ProjectEntity FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public ProjectEntity Remove()
        {
            throw new NotImplementedException();
        }

        public ProjectEntity Update(ProjectEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
