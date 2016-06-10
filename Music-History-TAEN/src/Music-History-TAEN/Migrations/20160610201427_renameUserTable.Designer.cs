using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Music_History_TAEN.Models;

namespace MusicHistoryTAEN.Migrations
{
    [DbContext(typeof(MusicHistoryContext))]
    [Migration("20160610201427_renameUserTable")]
    partial class renameUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Music_History_TAEN.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumTitle");

                    b.Property<string>("Artist");

                    b.Property<int?>("ArtistId");

                    b.Property<int>("YearReleased");

                    b.HasKey("AlbumId");

                    b.HasIndex("ArtistId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Music_History_TAEN.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName");

                    b.Property<int?>("UsersUserId");

                    b.HasKey("ArtistId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Music_History_TAEN.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlbumId");

                    b.Property<string>("AlbumTitle");

                    b.Property<string>("Author");

                    b.Property<string>("Genre");

                    b.Property<string>("TrackTitle");

                    b.HasKey("TrackId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("Music_History_TAEN.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Music_History_TAEN.Models.Album", b =>
                {
                    b.HasOne("Music_History_TAEN.Models.Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId");
                });

            modelBuilder.Entity("Music_History_TAEN.Models.Artist", b =>
                {
                    b.HasOne("Music_History_TAEN.Models.Users")
                        .WithMany()
                        .HasForeignKey("UsersUserId");
                });

            modelBuilder.Entity("Music_History_TAEN.Models.Track", b =>
                {
                    b.HasOne("Music_History_TAEN.Models.Album")
                        .WithMany()
                        .HasForeignKey("AlbumId");
                });
        }
    }
}
