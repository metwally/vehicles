using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VehiclesCore;

namespace VehiclesCore.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("VehiclesCore.Models.VehicleStatus", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerID");

                    b.Property<string>("Status");

                    b.Property<DateTime>("StatusTime");

                    b.Property<string>("VehicleID");

                    b.HasKey("StatusID");

                    b.ToTable("AllStatus");
                });
        }
    }
}
