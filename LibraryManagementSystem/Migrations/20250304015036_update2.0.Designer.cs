﻿// <auto-generated />
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20250304015036_update2.0")]
    partial class update20
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("LibraryManagementSystem.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Name = "Charles Dickens"
                        },
                        new
                        {
                            AuthorId = 2,
                            Name = "Lewis Carroll"
                        },
                        new
                        {
                            AuthorId = 3,
                            Name = "Agatha Christie"
                        },
                        new
                        {
                            AuthorId = 4,
                            Name = "J.K. Rowling"
                        },
                        new
                        {
                            AuthorId = 5,
                            Name = "Paulo Coelho"
                        },
                        new
                        {
                            AuthorId = 6,
                            Name = "Dan Brown"
                        },
                        new
                        {
                            AuthorId = 7,
                            Name = "J.D. Salinger"
                        },
                        new
                        {
                            AuthorId = 8,
                            Name = "Charles Dickens"
                        },
                        new
                        {
                            AuthorId = 9,
                            Name = "George Eliot"
                        },
                        new
                        {
                            AuthorId = 10,
                            Name = "F. Scott Fitzgerald"
                        },
                        new
                        {
                            AuthorId = 11,
                            Name = "Truman Capote"
                        },
                        new
                        {
                            AuthorId = 12,
                            Name = "Aldous Huxley"
                        },
                        new
                        {
                            AuthorId = 13,
                            Name = "Fyodor Dostoevsky"
                        },
                        new
                        {
                            AuthorId = 14,
                            Name = "J.P. Donleavy"
                        },
                        new
                        {
                            AuthorId = 15,
                            Name = "Johanna Spyri"
                        },
                        new
                        {
                            AuthorId = 16,
                            Name = "Lucy Maud Montgomery"
                        },
                        new
                        {
                            AuthorId = 17,
                            Name = "Harper Lee"
                        },
                        new
                        {
                            AuthorId = 18,
                            Name = "E.B. White"
                        },
                        new
                        {
                            AuthorId = 19,
                            Name = "Antoine de Saint-Exupéry"
                        },
                        new
                        {
                            AuthorId = 20,
                            Name = "J.R.R. Tolkien"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LibraryBranchId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("YearPublished")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LibraryBranchId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            ISBN = "978-3-16-148410-0",
                            LibraryBranchId = 1,
                            Title = "A Tale of Two Cities",
                            YearPublished = 2024
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            ISBN = "978-3-16-148410-1",
                            LibraryBranchId = 2,
                            Title = "Alice's Adventures in Wonderland",
                            YearPublished = 2024
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 3,
                            ISBN = "978-3-16-148410-2",
                            LibraryBranchId = 3,
                            Title = "And Then There Were None",
                            YearPublished = 2023
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 4,
                            ISBN = "978-3-16-148410-3",
                            LibraryBranchId = 4,
                            Title = "Harry Potter and the Philosopher's Stone",
                            YearPublished = 1998
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 5,
                            ISBN = "978-3-16-148410-4",
                            LibraryBranchId = 5,
                            Title = "The Alchemist ",
                            YearPublished = 1996
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 6,
                            ISBN = "978-3-16-148410-5",
                            LibraryBranchId = 6,
                            Title = "The Da Vinci Code",
                            YearPublished = 1997
                        },
                        new
                        {
                            BookId = 7,
                            AuthorId = 7,
                            ISBN = "978-3-16-148410-6",
                            LibraryBranchId = 7,
                            Title = "The Catcher in the Rye",
                            YearPublished = 2024
                        },
                        new
                        {
                            BookId = 8,
                            AuthorId = 8,
                            ISBN = "978-3-16-148410-7",
                            LibraryBranchId = 8,
                            Title = "Great Expectations",
                            YearPublished = 2025
                        },
                        new
                        {
                            BookId = 9,
                            AuthorId = 9,
                            ISBN = "978-3-16-148410-8",
                            LibraryBranchId = 9,
                            Title = "Middlemarch",
                            YearPublished = 2003
                        },
                        new
                        {
                            BookId = 10,
                            AuthorId = 10,
                            ISBN = "978-3-16-148410-9",
                            LibraryBranchId = 10,
                            Title = "The Great Gatsby",
                            YearPublished = 2008
                        },
                        new
                        {
                            BookId = 11,
                            AuthorId = 11,
                            ISBN = "978-3-16-148410-10",
                            LibraryBranchId = 11,
                            Title = "Cold Blood ",
                            YearPublished = 2009
                        },
                        new
                        {
                            BookId = 12,
                            AuthorId = 12,
                            ISBN = "978-3-16-148410-11",
                            LibraryBranchId = 12,
                            Title = "Brave New World ",
                            YearPublished = 2018
                        },
                        new
                        {
                            BookId = 13,
                            AuthorId = 13,
                            ISBN = "978-3-16-148410-12",
                            LibraryBranchId = 13,
                            Title = "Crime and Punishment",
                            YearPublished = 2013
                        },
                        new
                        {
                            BookId = 14,
                            AuthorId = 14,
                            ISBN = "978-3-16-148410-13",
                            LibraryBranchId = 14,
                            Title = "The Ginger Man",
                            YearPublished = 2011
                        },
                        new
                        {
                            BookId = 15,
                            AuthorId = 15,
                            ISBN = "978-3-16-148410-14",
                            LibraryBranchId = 15,
                            Title = "Heidi",
                            YearPublished = 2020
                        },
                        new
                        {
                            BookId = 16,
                            AuthorId = 16,
                            ISBN = "978-3-16-148410-15",
                            LibraryBranchId = 16,
                            Title = "Anne of Green Gables",
                            YearPublished = 1957
                        },
                        new
                        {
                            BookId = 17,
                            AuthorId = 17,
                            ISBN = "978-3-16-148410-16",
                            LibraryBranchId = 17,
                            Title = "To Kill a Mockingbird",
                            YearPublished = 1953
                        },
                        new
                        {
                            BookId = 18,
                            AuthorId = 18,
                            ISBN = "978-3-16-148410-17",
                            LibraryBranchId = 18,
                            Title = "Charlotte's Web",
                            YearPublished = 1830
                        },
                        new
                        {
                            BookId = 19,
                            AuthorId = 19,
                            ISBN = "978-3-16-148410-18",
                            LibraryBranchId = 19,
                            Title = "The Little Prince ",
                            YearPublished = 1999
                        },
                        new
                        {
                            BookId = 20,
                            AuthorId = 20,
                            ISBN = "978-3-16-148410-19",
                            LibraryBranchId = 20,
                            Title = "The Hobbit",
                            YearPublished = 2888
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "john.doe@example.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "jane.smith@example.com",
                            Name = "Jane Smith"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "michael.brown@example.com",
                            Name = "Michael Brown"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "emily.davis@example.com",
                            Name = "Emily Davis"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "david.johnson@example.com",
                            Name = "David Johnson"
                        },
                        new
                        {
                            CustomerId = 6,
                            Email = "sophia.lee@example.com",
                            Name = "Sophia Lee"
                        },
                        new
                        {
                            CustomerId = 7,
                            Email = "william.harris@example.com",
                            Name = "William Harris"
                        },
                        new
                        {
                            CustomerId = 8,
                            Email = "olivia.clark@example.com",
                            Name = "Olivia Clark"
                        },
                        new
                        {
                            CustomerId = 9,
                            Email = "james.martinez@example.com",
                            Name = "James Martinez"
                        },
                        new
                        {
                            CustomerId = 10,
                            Email = "ava.rodriguez@example.com",
                            Name = "Ava Rodriguez"
                        },
                        new
                        {
                            CustomerId = 11,
                            Email = "liam.wilson@example.com",
                            Name = "Liam Wilson"
                        },
                        new
                        {
                            CustomerId = 12,
                            Email = "isabella.anderson@example.com",
                            Name = "Isabella Anderson"
                        },
                        new
                        {
                            CustomerId = 13,
                            Email = "benjamin.thomas@example.com",
                            Name = "Benjamin Thomas"
                        },
                        new
                        {
                            CustomerId = 14,
                            Email = "charlotte.taylor@example.com",
                            Name = "Charlotte Taylor"
                        },
                        new
                        {
                            CustomerId = 15,
                            Email = "ethan.moore@example.com",
                            Name = "Ethan Moore"
                        },
                        new
                        {
                            CustomerId = 16,
                            Email = "amelia.jackson@example.com",
                            Name = "Amelia Jackson"
                        },
                        new
                        {
                            CustomerId = 17,
                            Email = "alexander.white@example.com",
                            Name = "Alexander White"
                        },
                        new
                        {
                            CustomerId = 18,
                            Email = "mia.harris@example.com",
                            Name = "Mia Harris"
                        },
                        new
                        {
                            CustomerId = 19,
                            Email = "lucas.martin@example.com",
                            Name = "Lucas Martin"
                        },
                        new
                        {
                            CustomerId = 20,
                            Email = "zoe.lee@example.com",
                            Name = "Zoe Lee"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.LibraryBranch", b =>
                {
                    b.Property<int>("LibraryBranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LibraryBranchId");

                    b.ToTable("LibraryBranch");

                    b.HasData(
                        new
                        {
                            LibraryBranchId = 1,
                            BranchName = "Vancouver Public Library Central Branch"
                        },
                        new
                        {
                            LibraryBranchId = 2,
                            BranchName = "Vancouver Public Library Kitsilano Branch"
                        },
                        new
                        {
                            LibraryBranchId = 3,
                            BranchName = "Vancouver Public Library Mount Pleasant Branch"
                        },
                        new
                        {
                            LibraryBranchId = 4,
                            BranchName = "Vancouver Public Library Renfrew Branch"
                        },
                        new
                        {
                            LibraryBranchId = 5,
                            BranchName = "Vancouver Public Library Dunbar Branch"
                        },
                        new
                        {
                            LibraryBranchId = 6,
                            BranchName = "Vancouver Public Library Kerrisdale Branch"
                        },
                        new
                        {
                            LibraryBranchId = 7,
                            BranchName = "Vancouver Public Library Main Branch"
                        },
                        new
                        {
                            LibraryBranchId = 8,
                            BranchName = "Vancouver Public Library Marpole Branch"
                        },
                        new
                        {
                            LibraryBranchId = 9,
                            BranchName = "Vancouver Public Library Hastings Branch"
                        },
                        new
                        {
                            LibraryBranchId = 10,
                            BranchName = "Vancouver Public Library Collingwood Branch"
                        },
                        new
                        {
                            LibraryBranchId = 11,
                            BranchName = "Vancouver Public Library Point Grey Branch"
                        },
                        new
                        {
                            LibraryBranchId = 12,
                            BranchName = "Vancouver Public Library Fraserview Branch"
                        },
                        new
                        {
                            LibraryBranchId = 13,
                            BranchName = "Vancouver Public Library Strathcona Branch"
                        },
                        new
                        {
                            LibraryBranchId = 14,
                            BranchName = "Vancouver Public Library Renfrew-Collingwood Branch"
                        },
                        new
                        {
                            LibraryBranchId = 15,
                            BranchName = "Vancouver Public Library Sunrise Branch"
                        },
                        new
                        {
                            LibraryBranchId = 16,
                            BranchName = "Vancouver Public Library Oakridge Branch"
                        },
                        new
                        {
                            LibraryBranchId = 17,
                            BranchName = "Vancouver Public Library Hastings-Sunrise Branch"
                        },
                        new
                        {
                            LibraryBranchId = 18,
                            BranchName = "Vancouver Public Library South Hill Branch"
                        },
                        new
                        {
                            LibraryBranchId = 19,
                            BranchName = "Vancouver Public Library Renfrew-Branch"
                        },
                        new
                        {
                            LibraryBranchId = 20,
                            BranchName = "Vancouver Public Library Queen Elizabeth Branch"
                        });
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Book", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagementSystem.Models.LibraryBranch", "LibraryBranch")
                        .WithMany()
                        .HasForeignKey("LibraryBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("LibraryBranch");
                });
#pragma warning restore 612, 618
        }
    }
}
