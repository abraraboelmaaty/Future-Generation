using FutureGeneration.Models;
using Microsoft.EntityFrameworkCore;

namespace FutureGeneration.Data
{
    public class Entites : DbContext
    {
        public Entites() : base() { }
        public Entites(DbContextOptions options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Cource>Cources { get; set; }
        public DbSet<StudentCource> StudentCources { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCource>()
           .HasKey(OP => new { OP.StudentId, OP.CourceId });
            modelBuilder.Entity<StudentCource>()
                      .HasOne(OP => OP.Student)
                      .WithMany(O => O.StudentCource)
                      .HasForeignKey(OP => OP.StudentId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
            modelBuilder.Entity<StudentCource>()
                      .HasOne(OP => OP.Cource)
                      .WithMany(P => P.StudentCource)
                      .HasForeignKey(OP => OP.CourceId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .IsRequired(false);
        }
    }
}
