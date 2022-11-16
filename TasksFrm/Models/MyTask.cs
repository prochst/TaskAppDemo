
namespace TasksFrm.Models
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
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public MyTaskState state { get; set; } = MyTaskState.New;
        public string owner { get; set; } = string.Empty;
    }
}
