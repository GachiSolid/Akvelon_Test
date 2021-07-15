using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akvelon_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace Akvelon_Test.API
{
    public interface IWorkerWithProject
    {
        /// <summary>
        /// Get all projects
        /// </summary>
        public Task<IEnumerable<Project>> Get();

        /// <summary>
        /// Get one project by id
        /// </summary>
        public Task<Project> Get(int id);

        /// <summary>
        /// Add new project
        /// </summary>
        public Task<Project> Post(Project project);

        /// <summary>
        /// Change project info
        /// </summary>
        public Task<Project> Put(Project project);

        /// <summary>
        /// Delete project
        /// </summary>
        public Task<int> Delete(int id);
    }
}
