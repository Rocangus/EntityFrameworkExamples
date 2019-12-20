using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExamples.Core.ViewModels
{
    public class StudentListViewModel
    {
        public int Id { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public string AddressStreet { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCity { get; set; }
    }
}
