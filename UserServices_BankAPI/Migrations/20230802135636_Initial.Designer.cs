﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserServices_BankAPI;

#nullable disable

namespace UserServices_BankAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230802135636_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("UserServices_BankAPI.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNumberGenerated")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccountType")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CurrentAccountBalance")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreatred")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateLastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PinHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PinSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
