using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Homework5.models;

namespace Homework5.DAL
{
    // Class that gives us access to a DB
    public class HomeworkContext : DbContext
    {
        // Which database to connect to (details in web.config)
        public HomeworkContext() : base("name=HomeworkDB")
        {
            Database.SetInitializer<HomeworkContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Homework>().ToTable("Homeworks");
        }

        // Access to our Users table
        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}