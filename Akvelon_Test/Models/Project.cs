using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akvelon_Test.Models
{
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }
    public class Project
    {

        /// <summary>
        /// Project identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Project start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Project complete date
        /// </summary>
        public DateTime? CompleteDate { get; set; }

        /// <summary>
        /// Project status
        /// </summary>
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// Project priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Project's tasks
        /// </summary>
        public virtual List<Task> Tasks { get; set; } = new List<Task>();
    }
}
