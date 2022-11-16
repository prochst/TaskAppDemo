using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TasksApi.Data;
using TasksApi.Models;

namespace TasksApi.Routers
{
    public static class UsersEndpoint
    {
        public static RouteGroupBuilder UsersMap(this RouteGroupBuilder group)
        {
            group.MapGet("/", GetAll);
            group.MapGet("/{id}", GetOne);
            group.MapGet("/{username}/{password}", VerifyUser);
            group.MapPost("/", Create);

            return group;
        }
        /// <summary>
        /// Return all users records
        /// </summary>
        /// <param name="db"></param>
        /// <returns>User[] array in JSON format</returns>
        static async Task<IResult> GetAll(TasksDb db)
        {
            return TypedResults.Ok(await db.Users.ToArrayAsync());
        }

        /// <summary>
        /// Return selected user record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="db"></param>
        /// <returns>User in JSON format</returns>
        static async Task<IResult> GetOne(int id, TasksDb db)
        {
            return await db.Users.FindAsync(id)
                is User user
                    ? TypedResults.Ok(user)
                    : TypedResults.NotFound();
        }

        /// <summary>
        /// Create new User record
        /// </summary>
        /// <param name="user">User in JSON format</param>
        /// <param name="db"></param>
        /// <returns>User in JSON format</returns>
        static async Task<IResult> Create(User user, TasksDb db)
        {
            try 
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return TypedResults.Ok(user);
            }
            catch 
            {
                return TypedResults.Problem("User not created");
            }
        }

        /// <summary>
        /// Compare string with selected User password
        /// </summary>
        /// <param name="id">User.Id</param>
        /// <param name="Pwd">Compared password</param>
        /// <param name="db"></param>
        /// <returns>true if match, false if not</returns>
        static async Task<IResult> VerifyUser(string userName, string password, TasksDb db)
        {
            try
            {
                var user = await db.Users.Where(u => u.UserName == userName).FirstAsync();
                if (user.MatchPassword(password))
                    return TypedResults.Ok(user);
                else
                    return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound();
            }
        }
    }
}
