using System;
using Microsoft.EntityFrameworkCore;

using AdvWeb.Models;

namespace AdvWeb.DataAccessLayer
{
    public class MyDBContext : DbContext // IdentityDbContext<ApplicationUser>
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)

        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Applicant> Applicants { get; set; }
    }
}
