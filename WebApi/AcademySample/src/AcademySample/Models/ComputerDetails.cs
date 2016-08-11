using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySample.Models
{
    public class ComputerDetails
    {
        [Key]
        public string Name { get; set; }
        public string IpAddress { get; set; }
        public int Memory { get; set; }
        public string User { get; set; }

        public ICollection<UsageData> UsageDatas { get; set; }
    }
}