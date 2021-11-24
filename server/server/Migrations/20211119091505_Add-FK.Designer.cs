﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Models;

namespace server.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20211119091505_Add-FK")]
    partial class AddFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("server.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dayoff")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApproverId = 1,
                            CreatedAt = new DateTime(2021, 11, 19, 16, 15, 4, 895, DateTimeKind.Local).AddTicks(5431),
                            Dayoff = 5,
                            Email = "hr@gmail.com",
                            FullName = "Nguyen Van HR",
                            Password = "1234",
                            Role = "HR",
                            UpdatedAt = new DateTime(2021, 11, 19, 16, 15, 4, 896, DateTimeKind.Local).AddTicks(9188)
                        },
                        new
                        {
                            Id = 2,
                            ApproverId = 1,
                            CreatedAt = new DateTime(2021, 11, 19, 16, 15, 4, 898, DateTimeKind.Local).AddTicks(5806),
                            Dayoff = 5,
                            Email = "emp@gmail.com",
                            FullName = "Nguyen Van Emp",
                            Password = "1234",
                            Role = "Employee",
                            UpdatedAt = new DateTime(2021, 11, 19, 16, 15, 4, 898, DateTimeKind.Local).AddTicks(5833)
                        });
                });

            modelBuilder.Entity("server.Models.Employee", b =>
                {
                    b.HasOne("server.Models.Employee", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");
                });
#pragma warning restore 612, 618
        }
    }
}