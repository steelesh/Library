﻿// <auto-generated />
using System;
using IT3047C_FinalProj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IT3047C_FinalProj.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookMember", b =>
                {
                    b.Property<int>("FavoriteBooksMemberId")
                        .HasColumnType("int");

                    b.Property<int>("FavoritesBookId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteBooksMemberId", "FavoritesBookId");

                    b.HasIndex("FavoritesBookId");

                    b.ToTable("MemberFavoriteBooks", (string)null);
                });

            modelBuilder.Entity("BookMember1", b =>
                {
                    b.Property<int>("CurrentlyReadingBookId")
                        .HasColumnType("int");

                    b.Property<int>("CurrentlyReadingBooksMemberId")
                        .HasColumnType("int");

                    b.HasKey("CurrentlyReadingBookId", "CurrentlyReadingBooksMemberId");

                    b.HasIndex("CurrentlyReadingBooksMemberId");

                    b.ToTable("MemberCurrentlyReadingBooks", (string)null);
                });

            modelBuilder.Entity("BookMember2", b =>
                {
                    b.Property<int>("WantToReadBookId")
                        .HasColumnType("int");

                    b.Property<int>("WantToReadBooksMemberId")
                        .HasColumnType("int");

                    b.HasKey("WantToReadBookId", "WantToReadBooksMemberId");

                    b.HasIndex("WantToReadBooksMemberId");

                    b.ToTable("MemberWantToReadBooks", (string)null);
                });

            modelBuilder.Entity("IT3047C_FinalProj.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenreId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PublicationYear")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "Harper Lee",
                            GenreId = "F",
                            PublicationYear = 1960,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Yuval Noah Harari",
                            GenreId = "NF",
                            PublicationYear = 2011,
                            Title = "Sapiens: A Brief History of Humankind"
                        },
                        new
                        {
                            BookId = 3,
                            Author = "J.D. Salinger",
                            GenreId = "F",
                            PublicationYear = 1951,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            BookId = 4,
                            Author = "George Orwell",
                            GenreId = "F",
                            PublicationYear = 1949,
                            Title = "1984"
                        },
                        new
                        {
                            BookId = 5,
                            Author = "Aldous Huxley",
                            GenreId = "F",
                            PublicationYear = 1932,
                            Title = "Brave New World"
                        },
                        new
                        {
                            BookId = 6,
                            Author = "Fyodor Dostoevsky",
                            GenreId = "F",
                            PublicationYear = 1866,
                            Title = "Crime and Punishment"
                        },
                        new
                        {
                            BookId = 7,
                            Author = "F. Scott Fitzgerald",
                            GenreId = "F",
                            PublicationYear = 1925,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            BookId = 8,
                            Author = "Herman Melville",
                            GenreId = "F",
                            PublicationYear = 1851,
                            Title = "Moby-Dick"
                        },
                        new
                        {
                            BookId = 9,
                            Author = "Jane Austen",
                            GenreId = "F",
                            PublicationYear = 1813,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            BookId = 10,
                            Author = "Fyodor Dostoevsky",
                            GenreId = "F",
                            PublicationYear = 1880,
                            Title = "The Brothers Karamazov"
                        },
                        new
                        {
                            BookId = 11,
                            Author = "Charles Dickens",
                            GenreId = "F",
                            PublicationYear = 1859,
                            Title = "A Tale of Two Cities"
                        },
                        new
                        {
                            BookId = 12,
                            Author = "Cormac McCarthy",
                            GenreId = "F",
                            PublicationYear = 2006,
                            Title = "The Road"
                        },
                        new
                        {
                            BookId = 13,
                            Author = "Paulo Coelho",
                            GenreId = "F",
                            PublicationYear = 1988,
                            Title = "The Alchemist"
                        },
                        new
                        {
                            BookId = 14,
                            Author = "Homer",
                            GenreId = "F",
                            PublicationYear = -800,
                            Title = "The Odyssey"
                        },
                        new
                        {
                            BookId = 15,
                            Author = "Homer",
                            GenreId = "F",
                            PublicationYear = -750,
                            Title = "The Iliad"
                        });
                });

            modelBuilder.Entity("IT3047C_FinalProj.Models.Genre", b =>
                {
                    b.Property<string>("GenreId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = "F",
                            Name = "Fiction"
                        },
                        new
                        {
                            GenreId = "NF",
                            Name = "Non-Fiction"
                        },
                        new
                        {
                            GenreId = "MY",
                            Name = "Mystery"
                        },
                        new
                        {
                            GenreId = "SF",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            GenreId = "FA",
                            Name = "Fantasy"
                        },
                        new
                        {
                            GenreId = "RO",
                            Name = "Romance"
                        },
                        new
                        {
                            GenreId = "H",
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("IT3047C_FinalProj.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            Name = "Eric Miller"
                        },
                        new
                        {
                            MemberId = 2,
                            Name = "Miriam Boni"
                        },
                        new
                        {
                            MemberId = 3,
                            Name = "Steele Shreve"
                        },
                        new
                        {
                            MemberId = 4,
                            Name = "Zion Ivery"
                        });
                });

            modelBuilder.Entity("BookMember", b =>
                {
                    b.HasOne("IT3047C_FinalProj.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("FavoriteBooksMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IT3047C_FinalProj.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("FavoritesBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMember1", b =>
                {
                    b.HasOne("IT3047C_FinalProj.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("CurrentlyReadingBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IT3047C_FinalProj.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("CurrentlyReadingBooksMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMember2", b =>
                {
                    b.HasOne("IT3047C_FinalProj.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("WantToReadBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IT3047C_FinalProj.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("WantToReadBooksMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IT3047C_FinalProj.Models.Book", b =>
                {
                    b.HasOne("IT3047C_FinalProj.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
