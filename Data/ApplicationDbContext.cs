using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OsevniPlan.Models;

namespace OsevniPlan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<OsevniPlan.Models.Zahon> Zahon { get; set; }
        public DbSet<OsevniPlan.Models.Rok> Rok { get; set; }
        public DbSet<OsevniPlan.Models.Plodina> Plodina { get; set; }
    }
}
