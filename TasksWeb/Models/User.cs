using System.ComponentModel.DataAnnotations;

namespace TasksWeb.Models
{
    public class User
    {
        /// <summary>
        /// Representation of user data
        /// </summary>
        /// 
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

    }
}
