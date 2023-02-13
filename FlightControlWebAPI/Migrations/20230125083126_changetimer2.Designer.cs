﻿// <auto-generated />
using System;
using FlightControlWebAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightControlWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230125083126_changetimer2")]
    partial class changetimer2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightControlWebAPI.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Airline")
                        .HasColumnType("int");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDepartured")
                        .HasColumnType("bit");

                    b.Property<int?>("TerminalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TerminalId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightControlWebAPI.Models.Logger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<DateTime>("In")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Out")
                        .HasColumnType("datetime2");

                    b.Property<int>("TerminalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("TerminalId");

                    b.ToTable("Loggers");
                });

            modelBuilder.Entity("FlightControlWebAPI.Models.Terminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("WaitingTimeSeconds")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Terminals");
                });

            modelBuilder.Entity("FlightControlWebAPI.Models.Flight", b =>
                {
                    b.HasOne("FlightControlWebAPI.Models.Terminal", "Terminal")
                        .WithMany()
                        .HasForeignKey("TerminalId");

                    b.Navigation("Terminal");
                });

            modelBuilder.Entity("FlightControlWebAPI.Models.Logger", b =>
                {
                    b.HasOne("FlightControlWebAPI.Models.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightControlWebAPI.Models.Terminal", "Terminal")
                        .WithMany()
                        .HasForeignKey("TerminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Terminal");
                });
#pragma warning restore 612, 618
        }
    }
}
