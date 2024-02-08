﻿// <auto-generated />
using System;
using Encryptor.Infrastructure.PostgreSql.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Encryptor.WebApi.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20240205130055_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Encryptor.Infrastructure.PostgreSql.Entities.Ciphers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountUsage")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Ciphers");
                });

            modelBuilder.Entity("Encryptor.Infrastructure.PostgreSql.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CiphersId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EncryptedText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OriginalText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CiphersId");

                    b.ToTable("History");
                });

            modelBuilder.Entity("Encryptor.Infrastructure.PostgreSql.Entities.History", b =>
                {
                    b.HasOne("Encryptor.Infrastructure.PostgreSql.Entities.Ciphers", null)
                        .WithMany("History")
                        .HasForeignKey("CiphersId");
                });

            modelBuilder.Entity("Encryptor.Infrastructure.PostgreSql.Entities.Ciphers", b =>
                {
                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}