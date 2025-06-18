using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DailyPilot.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DailyPilot.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todos { get; set; }
        //    public DbSet<IdentityRole> Roles { get; set; }
        //    public DbSet<IdentityUserRole<string>> UserRoles { get; set; }
        //    public DbSet<IdentityUserClaim<string>> UserClaims { get; set; }
        //    public DbSet<IdentityUserLogin<string>> UserLogins { get; set; }
   
    }
}
