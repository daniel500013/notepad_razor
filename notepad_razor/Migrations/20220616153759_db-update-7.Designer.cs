// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using notepad_razor;

#nullable disable

namespace notepad_razor.Migrations
{
    [DbContext(typeof(NotepadDbContext))]
    [Migration("20220616153759_db-update-7")]
    partial class dbupdate7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("notepad_razor.Model.PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserClass")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("notepad_razor.Model.SubjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Subject = "Polski",
                            UserID = 1
                        },
                        new
                        {
                            Id = 2,
                            Subject = "Matematyka",
                            UserID = 1
                        },
                        new
                        {
                            Id = 3,
                            Subject = "Angielski",
                            UserID = 1
                        },
                        new
                        {
                            Id = 4,
                            Subject = "Polski",
                            UserID = 2
                        },
                        new
                        {
                            Id = 5,
                            Subject = "Matematyka",
                            UserID = 2
                        },
                        new
                        {
                            Id = 6,
                            Subject = "Angielski",
                            UserID = 2
                        });
                });

            modelBuilder.Entity("notepad_razor.Model.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Permission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserClass")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "user@user.com",
                            HashedPassword = "AQAAAAEAACcQAAAAEIPml6EhNHdTF/UFC00wwnH+Do5mwU1UCpl1Y9EERknTH8LE1a5gg7DVk7yj+LQt5g==",
                            NickName = "user",
                            Password = "user",
                            Permission = "User",
                            UserClass = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin@admin.com",
                            HashedPassword = "AQAAAAEAACcQAAAAEENAYcFrj25u9tzx+88HZpIpOBXVKV/LZb0clSVOE1fXy2hA++svzwO3jnjb3Wstxw==",
                            NickName = "admin",
                            Password = "admin",
                            Permission = "Admin",
                            UserClass = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
