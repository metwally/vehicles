using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiclesCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllStatus",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StatusTime = table.Column<DateTime>(nullable: false),
                    VehicleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllStatus", x => x.StatusID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllStatus");
        }
    }
}
