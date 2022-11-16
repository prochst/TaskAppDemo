using TasksApi.Data;
using TasksApi.Models;

namespace TaskApi.Data
{
    /// <summary>
    /// Fill database with test dataset
    /// </summary>
    public static class DbManager
    {
        public static void FillDb(TasksDb db)
        {
            db.Users.Add(new User { UserName = "admin", Password = "54321" });
            db.Users.Add(new User { UserName = "user", Password = "12345" });
            db.MyTasks.Add(new MyTask { Title = "Testovací úkol", Description = "Tento úkol je pro testování aplikace", Owner = "admin", State = MyTask.MyTaskState.Processed });
            db.MyTasks.Add(new MyTask { Title = "Splněný úkol", Description = "Je to dokončeno", Owner = "user", State = MyTask.MyTaskState.Finished });
            db.MyTasks.Add(new MyTask { Title = "Smazaný úkol", Owner = "user", State = MyTask.MyTaskState.Deleted });
            db.Comments.Add(new Comment { MyTaskId = 1, UserName = "user", Content = "Testovací komentář k testovacímu úkolu." });
            db.Comments.Add(new Comment { MyTaskId = 1, UserName = "admin", Content = "Reakce na testovací komentář k testovacímu úkolu." });
            db.Comments.Add(new Comment { MyTaskId = 2, UserName = "user", Content = "Splněno před termín, je nutné to zkontrolovat." });
            db.SaveChanges();
        }
    }
}
