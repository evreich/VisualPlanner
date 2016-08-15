using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VisualPlanner.Models
{
    public class UserModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо ввести e-mail")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необходимо ввести e-mail")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"8+[0-9]{3}-[0-9]{3}-[0-9]{2}-[0-9]{2}", ErrorMessage = "Некорректный телефон")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 20 символов")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необходимо ввести логин")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина логина должна быть от 3 до 20 символов")]
        [Display(Name = "Логин")]
        public string Login { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }

        public UserModel(string email, string password, string login)
        {
            Email = email;
            Password = password;
            Login = login;
            Tasks = new List<TaskModel>();
        }
    }
}