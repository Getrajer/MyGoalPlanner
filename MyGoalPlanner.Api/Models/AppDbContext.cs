using Microsoft.EntityFrameworkCore;
using MyGoalPlanner.Models;
using MyGoalPlanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGoalPlanner.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 

        public DbSet<TypeOfGoal> TypeOfGoals { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Motivator> Motivators { get; set; }
        public DbSet<GoalItem> GoalItems { get; set; }
        public DbSet<GoalContition> GoalContitions { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<FontAwesomeIcon> FontAwesomeIcons { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
