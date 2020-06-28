namespace Assignment2Library.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<authorTable> authorTables { get; set; }
        public virtual DbSet<bookTable> bookTables { get; set; }
        public virtual DbSet<publisherTable> publisherTables { get; set; }
        public virtual DbSet<rulesTable> rulesTables { get; set; }
        public virtual DbSet<usersTable> usersTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<authorTable>()
                .HasMany(e => e.bookTables)
                .WithRequired(e => e.authorTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<bookTable>()
                .HasMany(e => e.usersTables)
                .WithRequired(e => e.bookTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<publisherTable>()
                .HasMany(e => e.bookTables)
                .WithRequired(e => e.publisherTable)
                .WillCascadeOnDelete(false);
        }
    }
}
