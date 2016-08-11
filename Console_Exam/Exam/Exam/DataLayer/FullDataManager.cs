using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;

namespace Exam.DataLayer
{
    public class FullDataManager : DataManager
    {
        public override ComputerSummary GetComputerSummary()
        {
            var computerSummary = new ComputerSummary
            {
                Name = GetMetric(ComputerMetricsEnum.ComputerName),
                User = GetMetric(ComputerMetricsEnum.UserName),
                AvailableDiskSpaceGb = int.Parse(GetMetric(ComputerMetricsEnum.AvailableDiskSpaceGb)),
                Cpu = GetMetric(ComputerMetricsEnum.Cpu),
                Ram = int.Parse(GetMetric(ComputerMetricsEnum.AvailableRam)),
                VideoCard = GetMetric(ComputerMetricsEnum.VideoCard),
                Ip = IPAddress.Parse(GetMetric(ComputerMetricsEnum.Ip)),
                CpuUsage = int.Parse(GetMetric(ComputerMetricsEnum.CpuUsage)),
                RamUsage = int.Parse(GetMetric(ComputerMetricsEnum.RamUsage)),
                AverageDiskQueueLength = int.Parse(GetMetric(ComputerMetricsEnum.AverageDiskQueueLength))
            };
            return computerSummary;
        }

        public override List<string> GetApplicationList() => GetListFromWmi("win32_product");

        public override List<string> GetHardwareList() => GetListFromWmi("win32_pnpentity");

        private static List<string> GetListFromWmi(string query)
        {
            var list = new List<string>();
            var searcher = new ManagementObjectSearcher("select * from " + query);
            foreach (var obj in searcher.Get().Cast<ManagementObject>())
            {
                list.Add(obj["Name"]?.ToString());
            }

            return list;
        }
    }
}
