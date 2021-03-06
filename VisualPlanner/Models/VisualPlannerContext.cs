﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisualPlanner.Models
{
    public class VisualPlannerContext : IdentityDbContext<UserModel>
    {
        public VisualPlannerContext() : base("MySQLConnection", throwIfV1Schema: false)
        {
        }
        public static VisualPlannerContext Create()
        {
            return new VisualPlannerContext();
        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskViewModel> TaskViews { get; set; }
        public DbSet<ExceptionModel> Exceptions { get; set; }

    }
}