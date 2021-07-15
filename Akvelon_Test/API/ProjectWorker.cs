using Akvelon_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Akvelon_Test.API
{
    public class ProjectWorker : IWorkerWithProject
    {
        ApplicationContext db;
        public ProjectWorker(ApplicationContext context)
        {
            db = context;
        }

        /// <summary>
        /// Delete project
        /// </summary>
        public async Task<int> Delete(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.Id == id);
            if (project != null)
            {
                db.Projects.Remove(project);
                await db.SaveChangesAsync();
                return id;
            }
            return 0;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        public async Task<IEnumerable<Project>> Get()
        {
            return await db.Projects.OrderBy(x => x.Priority).Reverse().ToListAsync();
        }

        /// <summary>
        /// Get one project by id
        /// </summary>
        public async Task<Project> Get(int id)
        {
            return await db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Add new project
        /// </summary>
        public async Task<Project> Post(Project project)
        {
            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return project;
        }

        /// <summary>
        /// Change project info
        /// </summary>
        public async Task<Project> Put(Project project)
        {
            if (db.Projects.Any(x => x.Id == project.Id))
            {
                db.Update(project);
                await db.SaveChangesAsync();
                return project;
            }
            return null;
        }
    }
}
