﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VodovozWpfApp;

namespace VodovozWpfApp.Migrations
{
    [DbContext(typeof(VodovozClientDbContext))]
    partial class VodovozClientDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<string>("FatherName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sex")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("SubdivisionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasAlternateKey("Number");

                    b.HasIndex("AuthorId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Subdivision", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Subdivisions");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Employee", b =>
                {
                    b.HasOne("Vodovoz.Models.ClientSide.Database.Subdivision", "Subdivision")
                        .WithMany("Employees")
                        .HasForeignKey("SubdivisionId");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Order", b =>
                {
                    b.HasOne("Vodovoz.Models.ClientSide.Database.Employee", "Author")
                        .WithMany("Orders")
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Subdivision", b =>
                {
                    b.HasOne("Vodovoz.Models.ClientSide.Database.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Vodovoz.Models.ClientSide.Database.Subdivision", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
