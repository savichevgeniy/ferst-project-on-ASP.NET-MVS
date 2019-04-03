﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FormsAuthApp.Models
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FIO { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FIO { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}