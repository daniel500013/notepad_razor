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

            modelBuilder.Entity<SubjectModel>()
                .Property(s => s.Subject)
                .IsRequired();

            modelBuilder.Entity<UserModel>()
                .HasData(
                new UserModel()
                {
                    Id = 1,
                    Email = "user@user.com",
                    NickName = "user",
                    Password = "user",
                    HashedPassword = "AQAAAAEAACcQAAAAEIPml6EhNHdTF/UFC00wwnH+Do5mwU1UCpl1Y9EERknTH8LE1a5gg7DVk7yj+LQt5g==",
                    Permission = "User",
                    UserClass = 1
                },
                new UserModel()
                {
                    Id = 2,
                    Email = "admin@admin.com",
                    NickName = "admin",
                    Password = "admin",
                    HashedPassword = "AQAAAAEAACcQAAAAEENAYcFrj25u9tzx+88HZpIpOBXVKV/LZb0clSVOE1fXy2hA++svzwO3jnjb3Wstxw==",
                    Permission = "Admin",
                    UserClass = 1
                }
                );

            modelBuilder.Entity<SubjectModel>()
                .HasData(
                new SubjectModel()
                {
                    Id = 1,
                    Subject = "Polski",
                    UserID = 1
                },
                new SubjectModel()
                {
                    Id = 2,
                    Subject = "Matematyka",
                    UserID = 1
                },
                new SubjectModel()
                {
                    Id = 3,
                    Subject = "Angielski",
                    UserID = 1
                },
                new SubjectModel()
                {
                    Id = 4,
                    Subject = "Polski",
                    UserID = 2
                },
                new SubjectModel()
                {
                    Id = 5,
                    Subject = "Matematyka",
                    UserID = 2
                },
                new SubjectModel()
                {
                    Id = 6,
                    Subject = "Angielski",
                    UserID = 2
                }
                );
        }
    }
}
