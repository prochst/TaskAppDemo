using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TasksWeb.Models;

namespace TasksWeb.Api
{
    static class ApiManager
    {
        /// <summary>
        /// Enum for select API action
        /// </summary>
        public enum ApiAction
        {
            Get,
            Post,
            Put,
            Delete
        }
         
        static string ApiBaseUri = "http://localhost:5050/";
        static HttpClient client = new HttpClient { BaseAddress = new Uri(ApiManager.ApiBaseUri) };

        /// <summary>
        /// General method for call api action
        /// </summary>
        /// <param name="apiAction">Action fro enum ApiAction</param>
        /// <param name="uri">URI string for API action</param>
        /// <param name="data">data object for PUT or POST action</param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<String> SendApiRequest(ApiAction apiAction, string uri, Object data = null)
        {
            //StringContent content;
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                switch (apiAction)
                {
                    case ApiAction.Get:
                        responseMessage = await client.GetAsync(uri);
                        break;
                    case ApiAction.Post:
                        responseMessage = await client.PostAsync(uri, new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"));
                        break;
                    case ApiAction.Put:
                        responseMessage = await client.PutAsync(uri, new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json"));
                        break;
                    case ApiAction.Delete:
                        responseMessage = await client.DeleteAsync(uri);
                        break;
                }
                responseMessage.EnsureSuccessStatusCode();
                var responseContent =  await responseMessage.Content.ReadAsStringAsync();
                return responseContent;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); //pro provozní prostředí udělat logování chyb do souboru
                return null;
            }
        }

        /// <summary>
        /// Gets Tasks
        /// </summary>
        /// <param name="icludedDeleted">if true - return task also task with state.deleted</param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<List<MyTask>?> GetTasks(Boolean icludedDeleted = false)
        {
            try
            {
                string uri = "tasks";
                if (icludedDeleted) uri = "tasks/incdel";
                var responseContent = await SendApiRequest(ApiAction.Get, uri);
                return JsonSerializer.Deserialize<List<MyTask>>(responseContent);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot access tasks from API");
            }
        }

        /// <summary>
        /// Verify user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<User?> VerifyUser(string username, string password)
        {
            string uri = "users/" + username + "/" + password;
            var responseContent = await SendApiRequest(ApiAction.Get, uri);
            return JsonSerializer.Deserialize<User>(responseContent);
        }
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<User?> RegisterUser(string username, string password)
        {
            User newUser = new User { userName = username, password = password };
            string uri = "users";
            var responseContent = await SendApiRequest(ApiAction.Post, uri, newUser);
            return JsonSerializer.Deserialize<User>(responseContent);
        }
        /// <summary>
        /// Update selected task
        /// </summary>
        /// <param name="myTask"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<MyTask>? UpdateTask(MyTask myTask)
        {
            string uri = "tasks/" + myTask.id;
            var responseContent = await SendApiRequest(ApiAction.Put, uri, myTask);
            return JsonSerializer.Deserialize<MyTask>(responseContent);
        }
        /// <summary>
        /// Create new task
        /// </summary>
        /// <param name="myTask"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<MyTask>? CreateTask(MyTask myTask)
        {
            string uri = "tasks";
            var responseContent = await SendApiRequest(ApiAction.Post, uri, myTask);
            return JsonSerializer.Deserialize<MyTask>(responseContent);
        }
        /// <summary>
        /// Delete selected task and associated comments
        /// </summary>
        /// <param name="myTask"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<MyTask>? DeleteTask(MyTask myTask, List<Comment> comments)
        {
            string uri = "tasks/" + myTask.id;
            var responseContent = await SendApiRequest(ApiAction.Delete, uri);
            // delete all associated comments
            foreach (Comment comment in comments)
            {
                DeleteComment(comment);
            }
            return JsonSerializer.Deserialize<MyTask>(responseContent);
        }
        /// <summary>
        /// Gets all comments joined with selected task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<List<Comment>?> GetComments4Taks(int taskId)
        {
            string uri = "comments/" + taskId;
            var responseContent = await SendApiRequest(ApiAction.Get, uri);
            return JsonSerializer.Deserialize<List<Comment>>(responseContent);
        }
        /// <summary>
        /// Create new comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<Comment>? CreateComment(Comment comment)
        {
            string uri = "comments";
            var responseContent = await SendApiRequest(ApiAction.Post, uri, comment);
            return JsonSerializer.Deserialize<Comment>(responseContent);
        }
        /// <summary>
        /// Update comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<Comment>? UpdateComment(Comment comment)
        {
            string uri = "comments/" + comment.id; ;
            var responseContent = await SendApiRequest(ApiAction.Put, uri, comment);
            return JsonSerializer.Deserialize<Comment>(responseContent);
        }
        /// <summary>
        /// Delete selected comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns>Response of action as JSON string</returns>
        public static async Task<Comment>? DeleteComment(Comment comment)
        {
            string uri = "comments/" + comment.id;
            var responseContent = await SendApiRequest(ApiAction.Delete, uri);
            return JsonSerializer.Deserialize<Comment>(responseContent);
        }
    }
}
