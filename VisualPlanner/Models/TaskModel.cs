using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Display(Name = "Задача")]
        Task,
        [Display(Name = "Событие")]
        Event,
        [Display(Name = "Проект")]
        Project
    }

    public class TaskModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        
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
        public int Period { get; set; }
        
        [Display(Name = "Дата окончания повторений")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy hh:mm")]
        public DateTime EndPeriod { get; set; }

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
    }
}