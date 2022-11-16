﻿using Microsoft.EntityFrameworkCore;
using System;
using TasksApi.Models;

namespace TasksApi.Data
{
    public class TasksDb : DbContext
    {
        public TasksDb(DbContextOptions<TasksDb> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<MyTask> MyTasks => Set<MyTask>();
        public DbSet<Comment> Comments => Set<Comment>();

    }
}