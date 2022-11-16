using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TasksFrm.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TasksFrm.Api
{
    static class ApiManager
    {
        static string ApiUri = "http://localhost:5050/";
        static HttpClient client = new HttpClient { BaseAddress = new Uri(ApiManager.ApiUri) };

        private static void SetClient()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public static async Task<User?> VerifyUser(string username, string password)
        {
            SetClient();
            try
            {
                var responseMessage = await client.GetAsync("users/" + username + "/" + password, HttpCompletionOption.ResponseContentRead);
                var resultArray = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(resultArray);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); - pro provozní prostředí udělat logování chyb do souboru
                return null;
            }
        }
        public static async Task<User?> RegisterUser(string username, string password)
        {
            SetClient();
            User newUser = new User {userName = username, password = password};
            var serialize = JsonSerializer.Serialize(newUser);
            var content = new StringContent(serialize, Encoding.UTF8, "application/json");
            try
            {
                var responseMessage = await client.PostAsync("users", content );
                var resultArray = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<User>(resultArray);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //for production enviroment log errors to file
                return null;
            }
        }

        public static async Task<List<MyTask>?> GetTasks(Boolean icludedDeleted = false)
        {
            string uri = "tasks";
            if (icludedDeleted) uri = "tasks/incdel";
            SetClient();
            try
            {
                var responseMessage = await client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
                var resultArray = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize <List<MyTask>>(resultArray);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //for production enviroment log errors to file
                return null;
            }
        }

        public static async Task<MyTask>? UpdateTask(MyTask myTask)
        {
            SetClient();
            try
            {
                 var serialize = JsonSerializer.Serialize(myTask);
                var content = new StringContent(serialize, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("tasks/" + myTask.id, content);
                responseMessage.EnsureSuccessStatusCode();
                var resultArray = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MyTask>(resultArray);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //for production enviroment log errors to file
                return null;
            }
        }
        public static async Task<MyTask>? CreateTask(MyTask myTask)
        {
            SetClient();
            try
            {
                var serialize = JsonSerializer.Serialize(myTask);
                var content = new StringContent(serialize, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("tasks", content);
                responseMessage.EnsureSuccessStatusCode();
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MyTask>(responseContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //for production enviroment log errors to file
                return null;
            }
        }
        public static async Task<MyTask>? DeleteTask(MyTask myTask)
        {
            SetClient();
            try
            {
                var serialize = JsonSerializer.Serialize(myTask);
                var content = new StringContent(serialize, Encoding.UTF8, "application/json");
                var responseMessage = await client.DeleteAsync("tasks/" + myTask.id);
                responseMessage.EnsureSuccessStatusCode();
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<MyTask>(responseContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //for production enviroment log errors to file
                return null;
            }
        }
        public static async Task<List<Comment>?> GetComments4Taks(int taskId)
        {
            SetClient();
            try
            {
                var responseMessage = await client.GetAsync("comments/" + taskId.ToString(), HttpCompletionOption.ResponseContentRead);
                var resultArray = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Comment>>(resultArray);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message); - pro provozní prostředí udělat logování chyb do souboru
                return null;
            }
        }
        public static async Task<Comment>? CreateComment(Comment comment)
        {
            SetClient();
            try
            {
                var serialize = JsonSerializer.Serialize(comment);
                var content = new StringContent(serialize, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("comments", content);
                responseMessage.EnsureSuccessStatusCode();
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Comment>(responseContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  //for production enviroment log errors to file
                return null;
            }
        }
    }
}
