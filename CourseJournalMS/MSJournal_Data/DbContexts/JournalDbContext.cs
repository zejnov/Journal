using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Data.DbContexts
{
    public class JournalDbContext : DbContext
    {
        public JournalDbContext() : base(GetConnectionString()) { }

        public DbSet<Student> StudentDbSet { get; set; }

        public DbSet<Homework> HomeworkDbSet { get; set; }

        public DbSet<CourseDay> CoruseDayDbSet { get; set; }

        public DbSet<Course> CourseDbSet { get; set; }
        

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JournalZejnovSql"].ConnectionString;
        }
    }
}
