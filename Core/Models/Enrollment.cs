﻿namespace EntityFrameworkExamples.Core.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}