using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial.Web.Models;

namespace Tutorial.Web.Data
{
    public class UserDbContext:IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options):base(options)
        {

        }
    }
}
