using DashboardWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardWeb.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        // DBContext Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
