﻿// <auto-generated />
using System;
using Karoo_KS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Karoo_KS.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20231005134801_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Karoo_KS.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
