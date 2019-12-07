namespace HW8.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using HW8.Models;

    public partial class RaceContext : DbContext
    {
        public RaceContext()
            : base("name=RaceContext_Azure")
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Meet> Meets { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamsandAthlete> TeamsandAthletes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
