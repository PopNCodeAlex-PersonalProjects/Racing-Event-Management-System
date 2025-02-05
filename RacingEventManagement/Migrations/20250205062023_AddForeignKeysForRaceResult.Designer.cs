﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RacingEventManagement.Models.Context;

#nullable disable

namespace RacingEventManagement.Migrations
{
    [DbContext(typeof(RacingContext))]
    [Migration("20250205062023_AddForeignKeysForRaceResult")]
    partial class AddForeignKeysForRaceResult
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RacingEventManagement.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ParticipantId"));

                    b.Property<int>("ExperienceYears")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("RacingEventManagement.Models.Race", b =>
                {
                    b.Property<int>("RaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RaceId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Distance")
                        .HasColumnType("double");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RaceId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("RacingEventManagement.Models.RaceResult", b =>
                {
                    b.Property<int>("RaceResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("RaceResultId"));

                    b.Property<double>("FinishTime")
                        .HasColumnType("double");

                    b.Property<int?>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("RaceId")
                        .HasColumnType("int");

                    b.HasKey("RaceResultId");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("RaceId");

                    b.ToTable("RacesResults");
                });

            modelBuilder.Entity("RacingEventManagement.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<double>("Horsepower")
                        .HasColumnType("double");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("TopSpeed")
                        .HasColumnType("double");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("RacingEventManagement.Models.RaceResult", b =>
                {
                    b.HasOne("RacingEventManagement.Models.Participant", null)
                        .WithMany("RaceResults")
                        .HasForeignKey("ParticipantId");

                    b.HasOne("RacingEventManagement.Models.Race", null)
                        .WithMany("RaceResults")
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("RacingEventManagement.Models.Participant", b =>
                {
                    b.Navigation("RaceResults");
                });

            modelBuilder.Entity("RacingEventManagement.Models.Race", b =>
                {
                    b.Navigation("RaceResults");
                });
#pragma warning restore 612, 618
        }
    }
}
