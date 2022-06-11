﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiFinal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherForecast",
                columns: table => new
                {
                    WeatherForecastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureC = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecast", x => x.WeatherForecastId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecast");
        }
    }
}
