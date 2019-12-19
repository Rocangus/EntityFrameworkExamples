using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExamples.Models
{
    public class EntityFrameworkExamplesContext : DbContext
    {
        public EntityFrameworkExamplesContext (DbContextOptions<EntityFrameworkExamplesContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
    }
}
