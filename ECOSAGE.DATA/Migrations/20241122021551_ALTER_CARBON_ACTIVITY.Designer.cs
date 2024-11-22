﻿// <auto-generated />
using System;
using ECOSAGE.DATA.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECOSAGE.DATA.Migrations
{
    [DbContext(typeof(OracleDbContext))]
    [Migration("20241122021551_ALTER_CARBON_ACTIVITY")]
    partial class ALTER_CARBON_ACTIVITY
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECOSAGE.DATA.models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("UserId");

                    b.ToTable("ECOSAGE_USER", (string)null);
                });

            modelBuilder.Entity("ECOSAGE.DATA.models.activity.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"));

                    b.Property<int?>("CarbonFootprintId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<decimal>("Emission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ActivityId");

                    b.HasIndex("CarbonFootprintId");

                    b.HasIndex("UserId");

                    b.ToTable("ECOSAGE_ACTIVITY", (string)null);
                });

            modelBuilder.Entity("ECOSAGE.DATA.models.carbonFootprint.CarbonFootprint", b =>
                {
                    b.Property<int>("CarbonFootprintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarbonFootprintId"));

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<decimal>("TotalEmission")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("CarbonFootprintId");

                    b.HasIndex("UserId");

                    b.ToTable("ECOSAGE_CARBONFOOTPRINT", (string)null);
                });

            modelBuilder.Entity("ECOSAGE.DATA.models.activity.Activity", b =>
                {
                    b.HasOne("ECOSAGE.DATA.models.carbonFootprint.CarbonFootprint", "CarbonFootprint")
                        .WithMany("Activities")
                        .HasForeignKey("CarbonFootprintId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ECOSAGE.DATA.models.User", "User")
                        .WithMany("Activities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarbonFootprint");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECOSAGE.DATA.models.carbonFootprint.CarbonFootprint", b =>
                {
                    b.HasOne("ECOSAGE.DATA.models.User", "User")
                        .WithMany("CarbonFootprints")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECOSAGE.DATA.models.User", b =>
                {
                    b.Navigation("Activities");

                    b.Navigation("CarbonFootprints");
                });

            modelBuilder.Entity("ECOSAGE.DATA.models.carbonFootprint.CarbonFootprint", b =>
                {
                    b.Navigation("Activities");
                });
#pragma warning restore 612, 618
        }
    }
}