using System.ComponentModel.DataAnnotations;

namespace VehiclesCore.Models
{
    public class VehicleStatus
    {
        [Key]
        public int StatusID {get; set;}
        public string CustomerID {get; set;}
        public string VehicleID {get; set;}
        public string Status {get; set;}
        public System.DateTime StatusTime {get; set;}
    }
}