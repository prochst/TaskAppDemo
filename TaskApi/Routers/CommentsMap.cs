using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TasksApi.Data;
using TasksApi.Models;

namespace TaskApi.Routers
{
    public static class CommentsEndpoint
    {
        public static RouteGroupBuilder CommentsMap(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAll);
            group.MapGet("/{taskid}", GetAll4Task);
            group.MapPost("/", Create);
            group.MapPut("/{id}", Update);
            group.MapDelete("/{id}", Delete);
            return group;
        }

        /// <summary>
        /// Return all comments
        /// </summary>
        /// <param name="db"></param>
        /// <returns>Commnet[] array in JSON format</returns>
        static async Task<IResult> GetAll(TasksDb db)
        {
            return TypedResults.Ok(await db.Comments.ToArrayAsync());
        }
        /// <summary>
        /// Return all comments belongs to selected task
        /// </summary>
        /// <param name="taskId">MyTask.Id</param>
        /// <param name="db"></param>
        /// <returns>Commnet[] array in JSON format</returns>
        static async Task<IResult> GetAll4Task(int taskId, TasksDb db)
        {
            return TypedResults.Ok(await db.Comments.Where(t => t.MyTaskId == taskId).ToArrayAsync());
        }
        /// <summary>
        /// Create new comment record
        /// </summary>
        /// <param name="comment">Comment</param>
        /// <param name="db"></param>
        /// <returns>Commnet in JSON format</returns>
        static async Task<IResult> Create(Comment comment, TasksDb db)
        {
            db.Comments.Add(comment);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/comments/{comment.Id}", comment);
        }
        /// <summary>
        /// Update content of comment selected comment
        /// </summary>
        /// <param name="id">Comment.Id</param>
        /// <param name="inputComment">Comment</param>
        /// <param name="db"></param>
        /// <returns>Commnet in JSON format</returns>
        static async Task<IResult> Update(int id, Comment inputComment, TasksDb db)
        {
            var comment = await db.Comments.FindAsync(id);

            if (comment is null) return TypedResults.NotFound();

            comment.Content = inputComment.Content;

            await db.SaveChangesAsync();
            return TypedResults.Ok(comment);
        }

        /// <summary>
        /// Delete selected comment
        /// </summary>
        /// <param name="id">Comment.Id</param>
        /// <param name="db"></param>
        /// <returns></returns>
        static async Task<IResult> Delete(int id, TasksDb db)
        {
            if (await db.Comments.FindAsync(id) is Comment comment)
            {
                db.Comments.Remove(comment);
                await db.SaveChangesAsync();
                return TypedResults.Ok(comment);
            }

            return TypedResults.NotFound();
        }
    }
}
