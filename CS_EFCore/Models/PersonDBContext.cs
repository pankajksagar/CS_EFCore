using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS_EFCore.Models
{
    public class PersonDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public PersonDBContext()
        {

        }

        /// <summary>
        /// configured db connection with application
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAB1-5; initial Catalog=PersonInfoDB; integrated Security = SSPI;");
        }

        /// <summary>
        /// provide mechanisam of model mapping while database and tables are created.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Person>();
        }
    }
}
