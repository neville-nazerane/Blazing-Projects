using BlazingProjects.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingProjects.DataAccess
{
    class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public DbSet<CardSection> CardSections { get; set; }

        public DbSet<Project> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
        }

    }
}
