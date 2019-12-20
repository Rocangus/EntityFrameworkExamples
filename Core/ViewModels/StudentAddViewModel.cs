using EntityFrameworkExamples.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExamples.Core.ViewModels
{
    public class StudentAddViewModel
    {
        public string Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Remote(action:"CheckEmail", controller:"Students")]
        public string Email { get; set; }
        [CheckStreetNr]
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipCode { get; set; }
    }
}
