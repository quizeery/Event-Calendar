using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunnyWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddEndDateToEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Events",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Events");
        }
    }
}
