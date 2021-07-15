using Akvelon_Test.API;
using Akvelon_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Akvelon_Test.Models.Task;

namespace Akvelon_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        readonly IWorkerWithTask tasks;
        public TaskController(IWorkerWithTask _tasks)
        {
            tasks = _tasks;
        }

        /// <summary>
        /// Get one task by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Task>> Get(int id)
        {
            Task task = await tasks.Get(id);
            if (task != null) return new ObjectResult(task);
            return NotFound();
        }

        /// <summary>
        /// Add new task
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Task>> Post(Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            return Ok(await tasks.Post(task));
        }

        /// <summary>
        /// Change task info
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<Task>> Put(Task task)
        {
            if (await tasks.Put(task) != null)
            {
                return Ok(task);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete task
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<Task>> Delete(int id)
        {
            if (await tasks.Delete(id) != 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
