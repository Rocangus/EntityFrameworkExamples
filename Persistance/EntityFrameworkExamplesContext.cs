using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkExamples.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkExamples.Data
{
    //To change migration path you only have to do this one time.
    //Add-Migration Init -OutputDir "Persistance/Migrations"
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
