using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiclesCore.Models;

namespace VehiclesCore.Controllers
{
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        [HttpPost]
        public IActionResult SetStatus ([FromBody]VehicleStatus status){
            if(!ModelState.IsValid){
                return Forbid();
            }

            using (var db = new DataContext())
            {
                var count = db.SaveStatus(status);
                Console.WriteLine("{0} records saved to database", count);
            }
            return Ok();

        }

        [HttpGet]
        public List<VehicleStatus> GetAllStatus(){
            using (var db = new DataContext())
            {
                List<VehicleStatus> AllStatus = db.GetAll();
                Console.WriteLine("{0} records retrieved from database", AllStatus.Count);
                return AllStatus;
            }
        }

        [Route("customer/{customerId}/")]
        [HttpGet]
        public List<VehicleStatus> GetStatusByCustomer(string customerId)
        {
            using (var db = new DataContext())
            {
                List<VehicleStatus> AllStatus = db.GetAllByCustomer(customerId);
                Console.WriteLine("{0} records retrieved from database", AllStatus.Count);
                return AllStatus;
            }
        }

        [Route("vehicle/{vehicleId}/")]
        [HttpGet]
        public List<VehicleStatus> GetStatusByVehicle(string vehicleId)
        {
            using (var db = new DataContext())
            {
                List<VehicleStatus> AllStatus = db.GetAllByVehicle(vehicleId);
                Console.WriteLine("{0} records retrieved from database", AllStatus.Count);
                return AllStatus;
            }
        }
    }
}