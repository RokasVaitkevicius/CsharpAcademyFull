using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademySample.Dto
{
    public class UsageDataDto
    {
        public int CpuUsage { get; set; }
        public int MemoryUsage { get; set; }
        public int AvailableDiskSpace { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
