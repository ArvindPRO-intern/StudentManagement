using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Repository.Entities;

namespace StudentManagement.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<StudentInfo> Students { get; set; }
        public DbSet<StudentContactInfo> StudentContacts { get; set; }

        public DbSet<StudentReport> StudentReports { get; set; }

        public DbSet<StudentMarks> StudentMarks{ get; set; }


    }
}
