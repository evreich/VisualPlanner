using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection; 
using System.ComponentModel.DataAnnotations;

namespace VisualPlanner.Models
{
    public enum Status
    {
        [Display(Name = "В ожидании")]
        Suspend,
        [Display(Name = "Выполняется")]
        During,
        [Display(Name = "Отменена")]
        Cancel,
        [Display(Name = "Выполнена")]
        Done
    }

    public enum Priority
    {
        [Display(Name = "Низкий")]
        Low,
        [Display(Name = "Средний")]
        Medium,
        [Display(Name = "Высокий")]
        High
    }

    public enum TaskType
    {
        [Display(Name = "Задача")]
        Task,
        [Display(Name = "Событие")]
        Event,
        [Display(Name = "Проект")]
        Project
    }

    public static class Enum_Helper
    {
        public static string GetDisplayName(this Enum value)
        {
            var type = value.GetType();
            if (!type.IsEnum) throw new ArgumentException(String.Format("Type '{0}' is not Enum", type));

            var members = type.GetMember(value.ToString());
            if (members.Length == 0) throw new ArgumentException(String.Format("Member '{0}' not found in type '{1}'", value, type.Name));

            var member = members[0];
            var attributes = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes.Length == 0) throw new ArgumentException(String.Format("'{0}.{1}' doesn't have DisplayAttribute", type.Name, value));

            var attribute = (DisplayAttribute)attributes[0];
            return attribute.GetName();
        }
    }

    public class TaskModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public string UserId { get; set; }
        
        [ScaffoldColumn(false)]
        public virtual UserModel User { get; set; }
        
        [Required(ErrorMessage = "Необходимо выбрать статус")]
        [Display(Name = "Статус")]
        public Status Status { get; set; }
        
        [Required(ErrorMessage = "Необходимо выбрать приоритет")]
        [Display(Name = "Приоритет")]
        public Priority Priority { get; set; }
        
        [Required(ErrorMessage = "Необходимо ввести название")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длина названия должна быть от 5 до 20 символов")]
        [Display(Name = "Название")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Необходимо указать дату")]
        [Display(Name = "Дата начала")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy hh:mm")]
        public DateTime TimeBegin { get; set; }
        
        [Required(ErrorMessage = "Необходимо указать дату")]
        [Display(Name = "Дата окончания")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy hh:mm")]
        public DateTime TimeEnd { get; set; }
        
        [Display(Name = "Описание")]
        [StringLength(100, ErrorMessage = "Длина описания должна быть до 100 символов")]
        public string Note { get; set; }
        
        [Display(Name = "Напоминание")]
        public bool Remind { get; set; }
        
        [Required(ErrorMessage = "Необходимо выбрать тип")]
        [Display(Name = "Тип")]
        public TaskType Type{ get; set; }
        
        [Display(Name = "Повторение")]
        public bool Repeat { get; set; }
        
        [Display(Name = "Периодичность")]
        [Range(1,1000, ErrorMessage = "Недопустимое значение")]
        public int? Period { get; set; }
        
        [Display(Name = "Дата окончания повторений")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy hh:mm")]
        public DateTime? EndPeriod { get; set; }

        [ScaffoldColumn(false)]
        public int? ProjectId { get; set; }

        [ScaffoldColumn(false)]
        public virtual List<TaskModel> Tasks { get; set; }

        [ScaffoldColumn(false)]
        public int? ParentTaskId { get; set; }

        [Display(Name = "Проект")]
        public TaskModel ParentTask { get; set; }

        [ScaffoldColumn(false)]
        public virtual List<TaskViewModel> TaskViews { get; set; }

        public TaskModel(string userId, string title, Status status, Priority priority, DateTime timeBegin, DateTime timeEnd, DateTime? endPeriod = null, int? period = null, int? projectId = null, string note = "", bool remind = false, TaskType type = TaskType.Task, bool repeat = false, int? parentTaskId = null)
        {
            UserId = userId;
            Title = title;
            Status = status;
            Priority = priority;
            TimeBegin = timeBegin;
            TimeEnd = timeEnd;
            Note = note;
            Type = type;
            Remind = remind;
            ParentTaskId = parentTaskId;
            Repeat = repeat;
            Period = period;
            EndPeriod = endPeriod;
        }
    }
}