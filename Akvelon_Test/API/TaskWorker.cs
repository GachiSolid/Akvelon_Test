using Akvelon_Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Akvelon_Test.Models.Task;

namespace Akvelon_Test.API
{
    public class TaskWorker : IWorkerWithTask
    {
        readonly ApplicationContext db;
        public TaskWorker(ApplicationContext context)
        {
            db = context;
        }

        /// <summary>
        /// Delete task
        /// </summary>
        public async Task<int> Delete(int id)
        {
            Task task = db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                db.Tasks.Remove(task);
                await db.SaveChangesAsync();
                return id;
            }
            return 0;
        }

        /// <summary>
        /// Get one task by id
        /// </summary>
        public async Task<Task> Get(int id)
        {
            return await db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Add new task
        /// </summary>
        public async Task<Task> Post(Task task)
        {
            db.Tasks.Add(task);
            await db.SaveChangesAsync();
            return task;
        }

        /// <summary>
        /// Change task info
        /// </summary>
        public async Task<Task> Put(Task task)
        {
            if (db.Tasks.Any(x => x.Id == task.Id))
            {
                db.Update(task);
                await db.SaveChangesAsync();
                return task;
            }
            return null;
        }
    }
}
