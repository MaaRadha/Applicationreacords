using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTrackerData.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobListings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CompanyMediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPerson1name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CompanyPerson2name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ContactPersonRole = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CompanyJobLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWebsiteLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmissionDate = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobListings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobListingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_JobListings_JobListingId",
                        column: x => x.JobListingId,
                        principalTable: "JobListings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_JobListingId",
                table: "Notes",
                column: "JobListingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "JobListings");
        }
    }
}
