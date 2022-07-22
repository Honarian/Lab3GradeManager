﻿// <auto-generated />
using Lab3GradeManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3GradeManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220722231030_AddClassroomsToDb")]
    partial class AddClassroomsToDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Lab3GradeManager.Model.Assignments", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"), 1L, 1);

                    b.Property<int>("AssignmentGrade")
                        .HasColumnType("int");

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Lab3GradeManager.Model.Classrooms", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("Lab3GradeManager.Model.Students", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int>("ClassroomsClassId")
                        .HasColumnType("int");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassroomsClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Lab3GradeManager.Model.Assignments", b =>
                {
                    b.HasOne("Lab3GradeManager.Model.Students", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Lab3GradeManager.Model.Students", b =>
                {
                    b.HasOne("Lab3GradeManager.Model.Classrooms", "Classrooms")
                        .WithMany()
                        .HasForeignKey("ClassroomsClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classrooms");
                });
#pragma warning restore 612, 618
        }
    }
}
