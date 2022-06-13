﻿namespace notepad_razor
{
    public class NotepadDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }

        public NotepadDbContext(DbContextOptions<NotepadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(p => p.Email)
                .IsRequired();

            modelBuilder.Entity<SubjectModel>()
                .Property(p => p.Subject)
                .IsRequired();


            modelBuilder.Entity<SubjectModel>()
                .Property(s => s.Subject)
                .IsRequired();
        }
    }
}