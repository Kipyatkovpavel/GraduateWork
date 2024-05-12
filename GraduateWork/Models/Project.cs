using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWork.Models
{
    public class Project
    {
        public required string ProjectName { get; set; }
        public required string ProjectSummary { get; set; }
        public required int ProjectDefaultAccess { get; set; }

    }

}
