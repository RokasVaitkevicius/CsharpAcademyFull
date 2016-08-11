using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademySample.Dto;
using AcademySample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AcademySample.Controllers
{
    [Route("api/computers")]
    public class ComputerDetailsController : Controller
    {
        private readonly ComputerDbContext _db;

        public ComputerDetailsController(ComputerDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("", Name="GetAllComputerDetails")]
        public List<ComputerDetailsDto> GetAll()
        {
            var computersList = new List<ComputerDetailsDto>();
            var computers = _db.ComputerDetails.ToList();
            foreach (var computer in computers)
            {
                var computersDto = new ComputerDetailsDto
                {
                    IpAddress = computer.IpAddress,
                    Memory = computer.Memory,
                    Name = computer.Name,
                    User = computer.User
                };

                computersList.Add(computersDto);
            }

            return computersList;
        }

        [HttpGet]
        [Route("{computerId}", Name="GetComputerById")]
        public ComputerDetailsDto GetById(string computerId)
        {
            var computer = _db.ComputerDetails.SingleOrDefault(cd => cd.Name == computerId);

            var computersDto = new ComputerDetailsDto
            {
                IpAddress = computer.IpAddress,
                Memory = computer.Memory,
                Name = computer.Name,
                User = computer.User
            };

            return computersDto;
        }

        [HttpGet]
        [Route("{computerId}/data", Name = "GetComputerUsageData")]
        public List<UsageDataDto> GetComputerUsageData(string computerId)
        {
            var usageDataList = new List<UsageDataDto>();

            var computer = _db.ComputerDetails
                .Include(ud => ud.UsageDatas)
                .SingleOrDefault(c => c.Name == computerId);

            var usageData = computer.UsageDatas;

            foreach (var data in usageData)
            {
                var usageDataDto = new UsageDataDto
                {
                    AvailableDiskSpace = data.AvailableDiskSpace,
                    CpuUsage = data.CpuUsage,
                    MemoryUsage = data.MemoryUsage,
                    TimeStamp = data.TimeStamp
                };

                usageDataList.Add(usageDataDto);
            }



            return usageDataList;
        }

        [HttpDelete]
        [Route("{computerId}")]
        public IActionResult Delete(string computerId)
        {
            var computer = _db.ComputerDetails.SingleOrDefault(c => c.Name == computerId);
            if (computer != null)
            {
                _db.ComputerDetails.Remove(computer);
                _db.SaveChanges();
            }
            return Ok();
        }


        [HttpPost]
        [Route("")]
        public IActionResult AddComputerDetails([FromBody] ComputerDetails computerDetails)
        {
            computerDetails.UsageDatas = new List<UsageData>();
            _db.ComputerDetails.Add(computerDetails);

            _db.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("{computerId}/data")]
        public IActionResult AddUsageData([FromBody] UsageData usageData, string computerId)
        {
            usageData.ComputerName = computerId;

            usageData.ComputerDetails = null;

            _db.UsageDatas.Add(usageData);

            _db.SaveChanges();

            return Ok();
        }

        


    }

    public class DummyData
    {
        public static IList<ComputerDetails> Computers { get;  }

        static DummyData()
        {
            Computers = new List<ComputerDetails>
            {
                new ComputerDetails {Name = "Computer1"},
                new ComputerDetails {Name = "Computer2"}
            };
        }
    }
}
