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

            modelBuilder.Entity("api.Models.DataEdit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DataProcessor30ListingDataId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EditType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldsEdited")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DataProcessor30ListingDataId");

                    b.ToTable("DataEditDatas");
                });

            modelBuilder.Entity("api.Models.DataProcessor30ListingData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("Archived")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("DataProcessor30ListingDatas");
                });

            modelBuilder.Entity("api.Models.DataSubProcessor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DataProcessor30ListingDataId")
                        .HasColumnType("int");

                    b.Property<bool>("DirectSubProcessor")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransferReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DataProcessor30ListingDataId");

                    b.ToTable("DataSubProcessors");
                });

            modelBuilder.Entity("api.Models.DataEdit", b =>
                {
                    b.HasOne("api.Models.DataProcessor30ListingData", "DataProcessor30ListingData")
                        .WithMany("DataEdits")
                        .HasForeignKey("DataProcessor30ListingDataId");

                    b.Navigation("DataProcessor30ListingData");
                });

            modelBuilder.Entity("api.Models.DataProcessor30ListingData", b =>
                {
                    b.OwnsOne("api.Models.DataCategories", "DataCategories", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("CategoryList")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.OwnsOne("api.Models.DataController", "DataController", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CVR")
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

                    b.OwnsOne("api.Models.DataControllerRepresentative", "DataControllerRepresentative", b1 =>
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

                            b1.Property<string>("Role")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.OwnsOne("api.Models.DataProcessor", "DataProcessor", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("CVR")
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

                    b.OwnsOne("api.Models.DataProcessorRepresentative", "DataProcessorRepresentative", b1 =>
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

                            b1.Property<string>("Role")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.OwnsOne("api.Models.DataSecurity", "DataSecurity", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("SecurityMeasures")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.OwnsOne("api.Models.DataSecurityAdvisor", "DataSecurityAdvisor", b1 =>
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

                    b.OwnsOne("api.Models.DataTransfer", "DataTransfer", b1 =>
                        {
                            b1.Property<int>("DataProcessor30ListingDataId")
                                .HasColumnType("int");

                            b1.Property<string>("TransferInformation")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DataProcessor30ListingDataId");

                            b1.ToTable("DataProcessor30ListingDatas");

                            b1.WithOwner()
                                .HasForeignKey("DataProcessor30ListingDataId");
                        });

                    b.Navigation("DataCategories")
                        .IsRequired();

                    b.Navigation("DataController")
                        .IsRequired();

                    b.Navigation("DataControllerRepresentative")
                        .IsRequired();

                    b.Navigation("DataProcessor")
                        .IsRequired();

                    b.Navigation("DataProcessorRepresentative")
                        .IsRequired();

                    b.Navigation("DataSecurity")
                        .IsRequired();

                    b.Navigation("DataSecurityAdvisor")
                        .IsRequired();

                    b.Navigation("DataTransfer")
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.DataSubProcessor", b =>
                {
                    b.HasOne("api.Models.DataProcessor30ListingData", "DataProcessor30ListingData")
                        .WithMany("DataSubProcessors")
                        .HasForeignKey("DataProcessor30ListingDataId");

                    b.Navigation("DataProcessor30ListingData");
                });

            modelBuilder.Entity("api.Models.DataProcessor30ListingData", b =>
                {
                    b.Navigation("DataEdits");

                    b.Navigation("DataSubProcessors");
                });
#pragma warning restore 612, 618
        }
    }
}
