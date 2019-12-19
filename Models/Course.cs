using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExamples.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int EnrollmentId { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
