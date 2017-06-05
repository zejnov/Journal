﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LeaderName { get; set; }
        public string LeaderSurname { get; set; }
        public DateTime StartDate { get; set; }
        public double HomeworkThreshold { get; set; }
        public double PresenceThreshold { get; set; }
        public int StudentsNumber { get; set; }

        public List<Student> CourseStudentsList { get; set; } = new List<Student>();
        public List<CourseDay> AttendanceList { get; set; } = new List<CourseDay>();  //attendance list
        public List<Homework> HomeworksList { get; set; } = new List<Homework>(); //homework list
        
        //public bool CourseIsActive { get; set; }
        //public bool CourseIsCreated { get; set; }
        
    }
}
