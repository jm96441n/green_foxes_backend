using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Webdev.TeamFoxesGreen.App.Data;

namespace green_foxes_backend.Migrations
{
    [DbContext(typeof(GreenFoxesDbContext))]
    partial class GreenFoxesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Webdev.TeamFoxesGreen.App.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Completed");

                    b.Property<string>("Description");

                    b.Property<int>("Priority");

                    b.Property<string>("Title");

                    b.Property<int>("User_Id");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });
            modelBuilder.Entity("Webdev.TeamFoxesGreen.App.Models.User", b =>
                {
                    b.Property<int>("Id").ValueGeneratedOnAdd();

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
