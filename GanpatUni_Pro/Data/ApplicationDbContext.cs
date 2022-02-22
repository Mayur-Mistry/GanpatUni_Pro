using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GanpatUni_Pro.Models;
namespace GanpatUni_Pro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Userm> Userms { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Query> Queries { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Group_Master> Group_Masters { get; set; }
        public DbSet<Group_Transaction> Group_Transactions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Announcement> Announcements { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public DbSet<GanpatUni_Pro.Models.Student> Student { get; set; }
    }
}
