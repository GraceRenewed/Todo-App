﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Todo_App;

#nullable disable

namespace Todo_App.Migrations
{
    [DbContext(typeof(Todo_AppDbContext))]
    [Migration("20250331020035_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Todo_App.Models.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            IsCompleted = true,
                            Task = "Make Grocery List"
                        },
                        new
                        {
                            Id = 102,
                            IsCompleted = false,
                            Task = "Buy groceries"
                        },
                        new
                        {
                            Id = 103,
                            IsCompleted = false,
                            Task = "Finish C# project"
                        },
                        new
                        {
                            Id = 104,
                            IsCompleted = true,
                            Task = "Call mom"
                        },
                        new
                        {
                            Id = 105,
                            IsCompleted = false,
                            Task = "Schedule dentist appointment"
                        },
                        new
                        {
                            Id = 106,
                            IsCompleted = true,
                            Task = "Read 10 pages of a book"
                        },
                        new
                        {
                            Id = 107,
                            IsCompleted = false,
                            Task = "Go for a 30-minute walk"
                        },
                        new
                        {
                            Id = 108,
                            IsCompleted = false,
                            Task = "Reply to emails"
                        },
                        new
                        {
                            Id = 109,
                            IsCompleted = false,
                            Task = "Plan weekend trip"
                        },
                        new
                        {
                            Id = 110,
                            IsCompleted = true,
                            Task = "Organize workspace"
                        },
                        new
                        {
                            Id = 111,
                            IsCompleted = false,
                            Task = "Meal prep for the week"
                        });
                });

            modelBuilder.Entity("Todo_App.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 201,
                            Name = "Penny"
                        });
                });

            modelBuilder.Entity("Todo_App.Models.ToDoItem", b =>
                {
                    b.HasOne("Todo_App.Models.UserProfile", null)
                        .WithMany("ToDoItems")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Todo_App.Models.UserProfile", b =>
                {
                    b.Navigation("ToDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
