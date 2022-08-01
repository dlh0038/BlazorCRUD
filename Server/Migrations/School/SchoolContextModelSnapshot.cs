﻿// <auto-generated />
using System;
using BlazorCRUD.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorCRUD.Server.Migrations.School
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("BlazorCRUD.Shared.ContosoUniversityModels.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BlazorCRUD.Shared.ContosoUniversityModels.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("BlazorCRUD.Shared.ContosoUniversityModels.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("BlazorCRUD.Shared.ContosoUniversityModels.Enrollment", b =>
                {
                    b.HasOne("BlazorCRUD.Shared.ContosoUniversityModels.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorCRUD.Shared.ContosoUniversityModels.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("BlazorCRUD.Shared.ContosoUniversityModels.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("BlazorCRUD.Shared.ContosoUniversityModels.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
