﻿using System;
using System.ComponentModel.DataAnnotations;
using Tutorial.Web.Models;

namespace Tutorial.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        [Display(Name = "名")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "姓"), Required, MaxLength(10)]
        public string LastName { get; set; }

        [Display(Name = "出生日期")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "性别")]
        public Gender Gender { get; set; }
    }
}
