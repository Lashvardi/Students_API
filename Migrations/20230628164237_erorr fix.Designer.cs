﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Students_APP.Data;

#nullable disable

namespace Students_APP.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230628164237_erorr fix")]
    partial class erorrfix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Students_APP.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Students_APP.Models.FinalProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectLink")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectName")
                        .HasColumnType("longtext");

                    b.Property<string>("StudentGuid")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentGuid");

                    b.ToTable("FinalProjects");
                });

            modelBuilder.Entity("Students_APP.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Students_APP.Models.Student", b =>
                {
                    b.Property<string>("Guid")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("Guid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Students_APP.Models.StudentCourse", b =>
                {
                    b.Property<string>("StudentGuid")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("StudentGuid", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("Students_APP.Models.StudentGroup", b =>
                {
                    b.Property<string>("StudentGuid")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("StudentGuid", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("Students_APP.Models.FinalProject", b =>
                {
                    b.HasOne("Students_APP.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Students_APP.Models.Student", "Student")
                        .WithMany("StudentFinalProjects")
                        .HasForeignKey("StudentGuid");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Students_APP.Models.Group", b =>
                {
                    b.HasOne("Students_APP.Models.Course", "Course")
                        .WithMany("Groups")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Students_APP.Models.StudentCourse", b =>
                {
                    b.HasOne("Students_APP.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Students_APP.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Students_APP.Models.StudentGroup", b =>
                {
                    b.HasOne("Students_APP.Models.Group", "Group")
                        .WithMany("StudentGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Students_APP.Models.Student", "Student")
                        .WithMany("StudentGroups")
                        .HasForeignKey("StudentGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Students_APP.Models.Course", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("Students_APP.Models.Group", b =>
                {
                    b.Navigation("StudentGroups");
                });

            modelBuilder.Entity("Students_APP.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");

                    b.Navigation("StudentFinalProjects");

                    b.Navigation("StudentGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
