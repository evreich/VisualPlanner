using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VisualPlanner.Models
{
    public class VisualPlannerContext : DbContext
    {
        public VisualPlannerContext() : base("MySQLConnection")
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskViewModel> TaskViews { get; set; }
        public DbSet<ExceptionModel> Exceptions { get; set; }

    }
}