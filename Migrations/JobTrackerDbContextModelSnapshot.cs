﻿// <auto-generated />
using System;
using JobTrackerData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobTrackerData.Migrations
{
    [DbContext(typeof(JobTrackerDbContext))]
    partial class JobTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobTrackerData.Models.JobListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyJobLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyMediaUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CompanyPerson1name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CompanyPerson2name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CompanyWebsiteLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonRole")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SubmissionDate")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("comments")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobListings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1234 Main St",
                            City = "Oslo",
                            CompanyJobLink = "https://www.company1.com/jobs",
                            CompanyMediaUrl = "https://www.company1.com",
                            CompanyName = "Company1",
                            CompanyPerson1name = "Person1",
                            CompanyPerson2name = "Person2",
                            CompanyWebsiteLink = "https://www.company1.com",
                            ContactEmail = "job@test@job.com",
                            ContactPersonPhone = "John doe",
                            ContactPersonRole = "Role1",
                            SubmissionDate = "2024-02-02",
                            Title = "Frontend developer",
                            comments = "This is comment"
                        });
                });

            modelBuilder.Entity("JobTrackerData.Models.Notes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobListingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobListingId");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "Company1",
                            Content = "Content1",
                            Date = new DateTime(2025, 2, 3, 22, 39, 0, 291, DateTimeKind.Local).AddTicks(7861),
                            JobListingId = 1
                        });
                });

            modelBuilder.Entity("JobTrackerData.Models.Notes", b =>
                {
                    b.HasOne("JobTrackerData.Models.JobListing", null)
                        .WithMany("Notes")
                        .HasForeignKey("JobListingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobTrackerData.Models.JobListing", b =>
                {
                    b.Navigation("Notes");
                });
#pragma warning restore 612, 618
        }
    }
}
