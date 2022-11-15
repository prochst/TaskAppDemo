using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksApi.Models
{
    /// <summary>
    /// Representation of comment data
    /// </summary>
    public class Comment
    {
        public int Id { get; set; }
        public int MyTaskId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime Create { get; set; } = DateTime.Now;
    }
}
