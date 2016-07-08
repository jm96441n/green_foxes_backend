using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Webdev.TeamFoxesGreen.App.Data;

namespace green_foxes_backend.Migrations
{
    [DbContext(typeof(GreenFoxesDbContext))]
    [Migration("20160706200904_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Webdev.TeamFoxesGreen.App.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Username");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
