using Microsoft.EntityFrameworkCore;
using TasksApi.Routers;
using TasksApi.Data;
using TasksApi.Models;
using TaskApi.Routers;
using TaskApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TasksDb>(opt => opt.UseInMemoryDatabase("TasksDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Prepare basic data colection
var db = app.Services.CreateScope().ServiceProvider.GetService<TasksDb>();
DbManager.FillDb(db);

// Define URI paths for datasets
app.MapGroup("/users").UsersMap().WithTags("Users Endpoints");
app.MapGroup("/tasks").MyTasksMap().WithTags("MyTasks Endpoint");
app.MapGroup("/comments").CommentsMap().WithTags("Comments Endpoint");

app.Run();