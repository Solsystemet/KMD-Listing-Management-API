﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.models.DataProcessor30ListingData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DataProcessor30ListingDatas");
                });

            modelBuilder.Entity("api.models.DataProcessor30ListingData", b =>
                {
                    b.OwnsOne("api.models.DataController", "DataController", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long>("CVR")
                                .HasColumnType("bigint");

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.OwnsOne("api.models.DataProcessor", "DataProcessor", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<long>("CVR")
                                .HasColumnType("bigint");

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.OwnsOne("api.models.DataProcessorRepresentative", "DataProcessorRepresentative", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Mail")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNo")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.Navigation("DataController")
                        .IsRequired();

                    b.Navigation("DataProcessor")
                        .IsRequired();

                    b.Navigation("DataProcessorRepresentative")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
