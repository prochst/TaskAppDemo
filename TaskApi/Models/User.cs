using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace TasksApi.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        /// <summary>
        /// Representation of user data
        /// </summary>
        private string _password = string.Empty;
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = PwdHasher.Hash(value); }
        }

        /// <summary>
        /// Compare string with user password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>true if match, false if not</returns>
        public bool MatchPassword(string password)
        {
            return PwdHasher.Verify(password, _password);
        }

    }
}
