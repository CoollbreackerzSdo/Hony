﻿// <auto-generated />
using System;
using Hony.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hony.Api.Migrations
{
    [DbContext(typeof(HonyNpSqlContext))]
    [Migration("20240531131100_V1")]
    partial class V1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Hony.Domain.Models.Account.AccountEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<DateOnly>("RegisterDate")
                        .HasColumnType("date")
                        .HasColumnName("register_date");

                    b.Property<TimeOnly>("RegisterTime")
                        .HasColumnType("time without time zone")
                        .HasColumnName("register_time");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserName");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Hony.Domain.Models.Account.AccountEntity", b =>
                {
                    b.OwnsOne("Hony.Domain.Models.Account.AccountDetail", "Detail", b1 =>
                        {
                            b1.Property<Guid>("AccountEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .ValueGeneratedOnUpdateSometimes()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("first_name");

                            b1.HasKey("AccountEntityId");

                            b1.ToTable("Accounts");

                            b1.ToJson("Detail");

                            b1.WithOwner()
                                .HasForeignKey("AccountEntityId");
                        });

                    b.OwnsOne("Hony.Domain.Models.Account.AccountSecurity", "Security", b1 =>
                        {
                            b1.Property<Guid>("AccountEntityId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .IsUnicode(true)
                                .HasColumnType("text")
                                .HasColumnName("email");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("password");

                            b1.HasKey("AccountEntityId");

                            b1.ToTable("Accounts");

                            b1.WithOwner()
                                .HasForeignKey("AccountEntityId");
                        });

                    b.Navigation("Detail")
                        .IsRequired();

                    b.Navigation("Security")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
