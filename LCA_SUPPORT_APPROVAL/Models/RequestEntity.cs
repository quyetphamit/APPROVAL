namespace LCA_SUPPORT_APPROVAL.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RequestEntity : DbContext
    {
        public RequestEntity()
            : base("name=Connection")
        {
        }

        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_Group> tbl_Group { get; set; }
        public virtual DbSet<tbl_Request> tbl_Request { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Customer>()
                .HasMany(e => e.tbl_Request)
                .WithRequired(e => e.tbl_Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Group>()
                .Property(e => e.permission)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Request>()
                .Property(e => e.currentError)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Request>()
                .Property(e => e.afterError)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Request>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Request>()
                .Property(e => e.pcb)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Request>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .HasMany(e => e.tbl_Request)
                .WithRequired(e => e.tbl_User)
                .HasForeignKey(e => e.userId_Create)
                .WillCascadeOnDelete(false);
        }
    }
}
