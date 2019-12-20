﻿using EntityFrameworkExamples.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExamples.Core.ViewModels
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipCode { get; set; }
        public int Attending { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
