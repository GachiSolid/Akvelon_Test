using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akvelon_Test.Models;
using Task = Akvelon_Test.Models.Task;

namespace Akvelon_Test.API
{
    public interface IWorkerWithTask
    {
        /// <summary>
        /// Get one task by id
        /// </summary>
        public Task<Task> Get(int id);

        /// <summary>
        /// Add new task
        /// </summary>
        public Task<Task> Post(Task task);

        /// <summary>
        /// Change task info
        /// </summary>
        public Task<Task> Put(Task task);

        /// <summary>
        /// Delete task
        /// </summary>
        public Task<int> Delete(int id);
    }
}
