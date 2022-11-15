using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TasksApi.Data;
using TasksApi.Models;

namespace TaskApi.Routers
{
    public static class MyTasksEndpoint
    {
        public static RouteGroupBuilder MyTasksMap(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAll);
            group.MapGet("/incdel", GetAllIncludeDeleted);
            group.MapGet("/{id}", GetOne);
            group.MapPost("/", Create);
            group.MapPut("/{id}", Update);
            group.MapDelete("/{id}", Delete);

            return group;
        }

        /// <summary>
        /// Return all non deleted taks
        /// </summary>
        /// <param name="db"></param>
        /// <returns>MyTasks[] array in JSON format</returns>
        static async Task<IResult> GetAll(TasksDb db)
        {
            return TypedResults.Ok(await db.MyTasks.Include(u => u.Owner).Where(t => t.State != MyTask.MyTaskState.Deleted).ToArrayAsync());
        }

        /// <summary>
        /// Return all taks
        /// </summary>
        /// <param name="db"></param>
        /// <returns>MyTasks[] array in JSON format</returns>
        static async Task<IResult> GetAllIncludeDeleted(TasksDb db)
        {
            return TypedResults.Ok(await db.MyTasks.Include(u => u.Owner).ToListAsync());
        }

        /// <summary>
        /// Return selected task
        /// </summary>
        /// <param name="id">MyTask.Id</param>
        /// <param name="db"></param>
        /// <returns>MyTask in JSON format</returns>
        static async Task<IResult> GetOne(int id, TasksDb db)
        {
            return await db.MyTasks.FindAsync(id)
                is MyTask myTask
                    ? TypedResults.Ok(myTask)
                    : TypedResults.NotFound();
        }

        /// <summary>
        /// Create new task record
        /// </summary>
        /// <param name="myTask">MyTask</param>
        /// <param name="db"></param>
        /// <returns>MyTask in JSON format</returns>
        static async Task<IResult> Create(MyTask myTask, TasksDb db)
        {
            db.MyTasks.Add(myTask);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/tasks/{myTask.Id}", myTask);
        }

        /// <summary>
        /// Update task record
        /// </summary>
        /// <param name="id">MyTask.Id of updated task</param>
        /// <param name="inputMyTask">MyTask</param>
        /// <param name="db"></param>
        /// <returns>MyTask in JSON format</returns>
        static async Task<IResult> Update(int id, MyTask inputMyTask, TasksDb db)
        {
            var myTask = await db.MyTasks.FindAsync(id);

            if (myTask is null) return TypedResults.NotFound();

            myTask.Title = inputMyTask.Title;
            myTask.Description = inputMyTask.Description;
            myTask.State = inputMyTask.State;

            await db.SaveChangesAsync();
            return TypedResults.Ok(myTask);
        }
        /// <summary>
        /// Delete selected task record
        /// </summary>
        /// <param name="id">MyTask.Id of deleted task</param>
        /// <param name="db"></param>
        /// <returns></returns>
        static async Task<IResult> Delete(int id, TasksDb db)
        {
            if (await db.MyTasks.FindAsync(id) is MyTask myTask)
            {
                db.MyTasks.Remove(myTask);
                await db.SaveChangesAsync();
                return TypedResults.Ok(myTask);
            }

            return TypedResults.NotFound();
        }
    }
}
