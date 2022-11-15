using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFrm.Models
{
    /// <summary>
    /// Representation of comment data
    /// </summary>
    public class Comment
    {
        public int id { get; set; }
        public int myTaskId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public DateTime create { get; set; } = DateTime.Now;
    }
}
