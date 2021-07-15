using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Test.Models
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }
    public class Task
    {
        /// <summary>
        /// Task identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Task name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Task status
        /// </summary>
        public TaskStatus Status { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Task priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Task's project id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Task's project
        /// </summary>
        public virtual Project Project { get; set; }
    }
}
