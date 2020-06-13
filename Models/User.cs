using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial.Web.Models
{
    public class User:IdentityUser
    {
        [Required]
        public override string UserName { get; set; }

    }
}
