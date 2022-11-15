using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MyTaskState State { get; set; } = MyTaskState.New;
        public virtual User? Owner { get; set; }
    }
}
