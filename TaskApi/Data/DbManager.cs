using TasksApi.Data;
using TasksApi.Models;

namespace TaskApi.Data
{
    /// <summary>
    /// Fill database with test dataset
    /// </summary>
    public static class DbManager
    {
        /// <summary>
        /// Creating test data during startup
        /// </summary>
        /// <param name="db"></param>
        public static void FillDb(TasksDb db)
        {
            db.Users.Add(new User { UserName = "admin", Password = "54321" });
            db.Users.Add(new User { UserName = "user1", Password = "12345" });
            db.Users.Add(new User { UserName = "user2", Password = "12345" });
            db.MyTasks.Add(new MyTask { Title = "Testovací úkol", Description = "Tento úkol je pro testování aplikace", Owner = "admin", State = MyTask.MyTaskState.Processed });
            db.MyTasks.Add(new MyTask { Title = "Splněný úkol", Description = "Je to dokončeno", Owner = "user1", State = MyTask.MyTaskState.Finished });
            db.MyTasks.Add(new MyTask { Title = "Smazaný úkol", Description = "Zadáno omylem", Owner = "user2", State = MyTask.MyTaskState.Deleted });
            db.Comments.Add(new Comment { MyTaskId = 1, UserName = "user1", Content = "Testovací komentář k testovacímu úkolu." });
            db.Comments.Add(new Comment { MyTaskId = 1, UserName = "admin", Content = "Reakce na testovací komentář k testovacímu úkolu." });
            db.Comments.Add(new Comment { MyTaskId = 2, UserName = "user1", Content = "Splněno před termínem, je nutné to zkontrolovat." });
            db.Comments.Add(new Comment { MyTaskId = 2, UserName = "user2", Content = "Kontrla proběhla, všechno je OK." });
            db.Comments.Add(new Comment { MyTaskId = 3, UserName = "user2", Content = "Úkol je možné smazat, byl vytvořen omylem" });
            db.SaveChanges();
        }
    }
}
