using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTrackerData.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data_to_entitys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobListings",
                columns: new[] { "Id", "Address", "City", "CompanyJobLink", "CompanyMediaUrl", "CompanyName", "CompanyPerson1name", "CompanyPerson2name", "CompanyWebsiteLink", "ContactEmail", "ContactPersonPhone", "ContactPersonRole", "SubmissionDate", "Title", "comments" },
                values: new object[] { 1, "1234 Main St", "Oslo", "https://www.company1.com/jobs", "https://www.company1.com", "Company1", "Person1", "Person2", "https://www.company1.com", "job@test@job.com", "John doe", "Role1", "2024-02-02", "Frontend developer", "This is comment" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CompanyName", "Content", "Date", "JobListingId" },
                values: new object[] { 1, "Company1", "Content1", new DateTime(2025, 2, 3, 16, 30, 27, 542, DateTimeKind.Local).AddTicks(3701), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobListings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
