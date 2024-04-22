using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;
using System;

namespace Simple_API_Assessment.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Applicant>().HasData(
              new Applicant() { Id = 1, Name = " Trevor Tshuma" }
              );

            builder.Entity<Skill>().HasData(
            new Skill() { Id = 1, Name = "Web Design", ApplicantId = 1 },
            new Skill() { Id = 2, Name = "Web Development", ApplicantId = 1 },
            new Skill() { Id = 3, Name = "Mobile App Development", ApplicantId = 1 }
            );


        }


        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Skill> Skills { get; set; }

    }
}
