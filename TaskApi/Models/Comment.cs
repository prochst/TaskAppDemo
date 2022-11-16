using System.ComponentModel.DataAnnotations;


namespace TasksApi.Models
{
    /// <summary>
    /// Representation of comment data
    /// </summary>
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MyTaskId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Create { get; set; } = DateTime.Now;
    }
}
