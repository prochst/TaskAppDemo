using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksApi.Models
{   
    /// <summary>
    /// Representation of task data
    /// </summary>
    public class MyTask
    {
        public enum MyTaskState
        {
            New,
            Processed,
            Finished,
            Deleted
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MyTaskState State { get; set; } = MyTaskState.New;
        [Required]
        public string Owner { get; set; } = string.Empty;
    }
}
