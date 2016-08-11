using Exam.DataLayer;
using Exam.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using static System.Console;

namespace Exam
{
    class Program
    {
        public static DataManager DataManager = new FullDataManager();

        static void Main(string[] args)
        {
            WriteLine("Please enter how often do you want to send data to WebAPi in seconds: ");

            var interval = ReadLine();
            var timer = new Timer(PostComputerUsageData, null, 0, int.Parse(interval) * 1000);
            ReadLine();

        }

        private static void PostComputerUsageData(object o)
        {
            using (var client = new HttpClient())
            {
                var processorUsage = double.Parse(DataManager.GetMetric(ComputerMetricsEnum.CpuUsage));
                var ramUsage = double.Parse(DataManager.GetMetric(ComputerMetricsEnum.RamUsage));

                client.BaseAddress = new Uri("http://192.168.10.106/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var newUsageReport = new NewUsageData { TimeStamp = DateTime.Now, ProcessorUsage = processorUsage, MemoryUsage = ramUsage };

                var json = JsonConvert.SerializeObject(newUsageReport);

                var content = new StringContent(json);

                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = client.PostAsync("api/virtualmachines/16/usagereports", content);

                var result = response.Result;

                WriteLine("Data:");
                WriteLine("Ram" + ramUsage);
                WriteLine("Cpu" + processorUsage);
                WriteLine();
            }
        }
    }
}
