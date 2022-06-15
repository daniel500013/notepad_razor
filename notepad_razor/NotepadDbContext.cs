namespace notepad_razor
{
    public class NotepadDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }

        public NotepadDbContext(DbContextOptions<NotepadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(p => p.Email)
                .IsRequired();

            modelBuilder.Entity<UserModel>()
                .Property(p => p.NickName)
                .IsRequired();

            modelBuilder.Entity<PostModel>()
                .Property(p => p.Subject)
                .IsRequired(false);

            modelBuilder.Entity<SubjectModel>();
        }
    }
}
