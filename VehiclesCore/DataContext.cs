using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VehiclesCore.Models;
using System;
using System.Linq;

namespace VehiclesCore
{
    public class DataContext : DbContext
    {
        public DbSet<VehicleStatus> AllStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=vehicle_status.db");
        }

        public int SaveStatus(VehicleStatus newStatus)
        {
            this.AllStatus.Add(newStatus);  
            var count = this.SaveChanges();
            return count;
        }
        public List<VehicleStatus> GetAll(){
            return this.AllStatus.ToList();
        }

        public List<VehicleStatus> GetAllByCustomer(string CustomerID){
            return this.AllStatus.Where(x => x.CustomerID == (string)CustomerID).ToList();
        }
        public List<VehicleStatus> GetAllByVehicle(string VehicleID){
            return this.AllStatus.Where(x => x.VehicleID == (string)VehicleID).ToList();
        } 
    }
}