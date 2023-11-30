using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActiveJobs.Migrations
{
    public partial class AlterTableJobsAddColumnActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Jobs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Jobs");
        }
    }
}
