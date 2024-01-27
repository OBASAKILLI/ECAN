﻿// <auto-generated />
using System;
using ECAN_CRF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECAN_CRF.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20231107130911_bafsgfdg")]
    partial class bafsgfdg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ECAN_CRF.Models.Centers", b =>
                {
                    b.Property<string>("strId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("CenterCode")
                        .IsRequired();

                    b.Property<string>("CenterName")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.HasKey("strId");

                    b.ToTable("centes");
                });

            modelBuilder.Entity("ECAN_CRF.Models.Events", b =>
                {
                    b.Property<string>("strId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<bool>("Isdelered");

                    b.Property<DateTime>("strDate");

                    b.Property<string>("strEvent")
                        .IsRequired();

                    b.Property<string>("strStudentId")
                        .IsRequired();

                    b.HasKey("strId");

                    b.ToTable("events");
                });

            modelBuilder.Entity("ECAN_CRF.Models.Schools", b =>
                {
                    b.Property<string>("strId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("CenterId")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("strId");

                    b.ToTable("schools");
                });

            modelBuilder.Entity("ECAN_CRF.Models.Sponsers", b =>
                {
                    b.Property<string>("strId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("stCountry")
                        .IsRequired();

                    b.Property<string>("stImageURl");

                    b.Property<string>("stName")
                        .IsRequired();

                    b.HasKey("strId");

                    b.ToTable("sponsers");
                });

            modelBuilder.Entity("ECAN_CRF.Models.Studens", b =>
                {
                    b.Property<string>("strId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("isDeleted");

                    b.Property<DateTime>("strADMDate");

                    b.Property<string>("strADNo")
                        .IsRequired();

                    b.Property<string>("strCenterId")
                        .IsRequired();

                    b.Property<string>("strCgrade_Class")
                        .IsRequired();

                    b.Property<DateTime>("strDateOfBirth");

                    b.Property<string>("strGuarduianName")
                        .IsRequired();

                    b.Property<string>("strName")
                        .IsRequired();

                    b.Property<string>("strSchoolId")
                        .IsRequired();

                    b.Property<string>("strSponserId")
                        .IsRequired();

                    b.Property<string>("strguardianPhone")
                        .IsRequired();

                    b.HasKey("strId");

                    b.ToTable("studens");
                });

            modelBuilder.Entity("ECAN_CRF.Models.Users", b =>
                {
                    b.Property<string>("strId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted");

                    b.Property<string>("strName")
                        .IsRequired();

                    b.Property<string>("strPassword")
                        .IsRequired();

                    b.Property<string>("strRole")
                        .IsRequired();

                    b.Property<string>("strUsername")
                        .IsRequired();

                    b.HasKey("strId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
