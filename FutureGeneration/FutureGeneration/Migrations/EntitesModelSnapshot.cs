﻿// <auto-generated />
using System;
using FutureGeneration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FutureGeneration.Migrations
{
    [DbContext(typeof(Entites))]
    partial class EntitesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FutureGeneration.Models.Cource", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CourseSyllabus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cources");

                    b.HasCheckConstraint("CK_Cources_Status_Enum", "[Status] IN (0, 1, 2)");
                });

            modelBuilder.Entity("FutureGeneration.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FutureGeneration.Models.StudentCource", b =>
                {
                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("CourceId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "CourceId");

                    b.HasIndex("CourceId");

                    b.ToTable("StudentCources");
                });

            modelBuilder.Entity("FutureGeneration.Models.StudentCource", b =>
                {
                    b.HasOne("FutureGeneration.Models.Cource", "Cource")
                        .WithMany("StudentCource")
                        .HasForeignKey("CourceId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FutureGeneration.Models.Student", "Student")
                        .WithMany("StudentCource")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Cource");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("FutureGeneration.Models.Cource", b =>
                {
                    b.Navigation("StudentCource");
                });

            modelBuilder.Entity("FutureGeneration.Models.Student", b =>
                {
                    b.Navigation("StudentCource");
                });
#pragma warning restore 612, 618
        }
    }
}
