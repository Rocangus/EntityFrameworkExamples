using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExamples.Services
{
    public class UniversitySettings : ISettings
    {
        public int Capacity { get; set; }

        public UniversitySettings(IConfiguration configuration)
        {
            Capacity = configuration.GetValue<int>("UniversitySettings:Capacity");
        }
    }
}
