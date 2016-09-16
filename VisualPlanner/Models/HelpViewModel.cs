using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisualPlanner.Models
{
    public class HelpViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести e-mail")]
        [Display(Name = "Введите ваш e-mail:")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Необходимо задать тему запроса")]
        [Display(Name = "Тема запроса:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Необходимо задать описание")]
        [Display(Name = "Описание:")]
        public string Comment { get; set; }
    }
}