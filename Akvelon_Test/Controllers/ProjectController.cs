using Akvelon_Test.Models;
using Akvelon_Test.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        readonly IWorkerWithProject projects;
        public ProjectController(IWorkerWithProject _projects)
        {
            projects = _projects;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return Ok(await projects.Get());
        }

        /// <summary>
        /// Get one project by id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            Project project = await projects.Get(id);
            if (project != null) return new ObjectResult(project);
            return NotFound();
        }

        /// <summary>
        /// Add new project
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            return Ok(await projects.Post(project));
        }

        /// <summary>
        /// Change project info
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<Project>> Put(Project project)
        {
            if (await projects.Put(project) != null)
            {
                return Ok(project);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete project
        /// </summary>
        [HttpDelete]
        public async Task<ActionResult<Project>> Delete(int id)
        {
            if (await projects.Delete(id) != 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
