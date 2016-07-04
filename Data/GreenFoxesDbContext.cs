using System;
using System.Linq;
using Webdev.TeamFoxesGreen.App.Models;
using Microsoft.EntityFrameworkCore;

namespace Webdev.TeamFoxesGreen.App.Data {

    public class GreenFoxesDbContext : DbContext {

        public DbSet<Task> Tasks {get;set;}

        public GreenFoxesDbContext(DbContextOptions<GreenFoxesDbContext> options) :base(options){

        }

    }
}