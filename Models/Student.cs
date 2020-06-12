using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Web.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }
    }
}
