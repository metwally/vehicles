using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using VehiclesCore;

namespace VehiclesCore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20170610125400_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
