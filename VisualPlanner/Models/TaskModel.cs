using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VisualPlanner.Models
{
    public enum Status
    {
        Suspend,
        During,
        Cancel,
        Done
    }

    public enum Priority
    {
        Low,
        Medium, 
        High
    }

    public enum TaskType
    {
        Task,
        Event,
        Project
    }

    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserModel User { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public Priority Priority { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime TimeBegin { get; set; }
        [Required]
        public DateTime TimeEnd { get; set; }
        public string Note { get; set; }
        [Required]
        public bool Remind { get; set; }
        [Required]
        public TaskType Type{ get; set; }
        public bool Repeat { get; set; }
        public int Period { get; set; }
        public DateTime EndPeriod { get; set; }
        public int? ProjectId { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }
        public int? TaskId { get; set; }
        public TaskModel ParentTask { get; set; }
        public virtual List<TaskViewModel> TaskViews { get; set; }

    }
}