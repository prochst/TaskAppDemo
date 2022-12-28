using TasksWeb.Models;

namespace TasksWeb.Shared
{
    /// <summary>
    /// Service class for handle logged user in application 
    /// </summary>
    public class LoginState
    {
        public string loggedUser { get; set; } = string.Empty;
        public bool isLogged { get; set; } = false;
        public bool isAdmin { get; set; } = false;

        public event Action? OnLoginChange;

        public void Login(string user, bool isadmin)
        {
            isLogged = true;
            loggedUser = user;
            isAdmin = isadmin;
            NotifyLoginChanged();
        }
        public void Logout()
        {
            isLogged = false;
            loggedUser = "";
            isAdmin = false;
            NotifyLoginChanged();
        }
        
        private void NotifyLoginChanged()
        {
            OnLoginChange?.Invoke();
        }
        
    }
}
