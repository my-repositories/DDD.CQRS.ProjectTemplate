// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using CompanyName.ProjectName.Domain.Authors.Entities;
using CompanyName.ProjectName.Domain.Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.ProjectName.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().ToTable("Authors");
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<BookAuthor>().ToTable("BookAuthors");

            modelBuilder.Entity<BookAuthor>()
                .HasKey(pc => new { pc.BookId, pc.AuthorId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
