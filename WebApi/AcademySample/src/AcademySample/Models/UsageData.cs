using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySample.Models
{
    public class UsageData
    {
        [Key]
        public int UsageDataId { get; set; }
        public int CpuUsage { get; set; }
        public int MemoryUsage { get; set; }
        public int AvailableDiskSpace { get; set; }
        public DateTime? TimeStamp { get; set; }

        public ComputerDetails ComputerDetails { get; set; }
        public string ComputerName { get; set; }
    }
}
