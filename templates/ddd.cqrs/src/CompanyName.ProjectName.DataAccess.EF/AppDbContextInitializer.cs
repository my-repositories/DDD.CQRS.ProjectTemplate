// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

using CompanyName.ProjectName.Domain.Authors.Entities;
using CompanyName.ProjectName.Domain.Books.Entities;

namespace CompanyName.ProjectName.DataAccess
{
    public static class AppDbContextInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }

            var authors = new[]
            {
                new Author { AuthorId = 1, FirstName = "Jeffrey", LastName = "Richter" },
                new Author { AuthorId = 2, FirstName = "Herbert", LastName = "Schildt" },
                new Author { AuthorId = 3, FirstName = "Erich", LastName = "Gamma" },
                new Author { AuthorId = 4, FirstName = "Richard", LastName = "Helm" },
                new Author { AuthorId = 5, FirstName = "John", LastName = "Vlissides" },
                new Author { AuthorId = 6, FirstName = "Ralph", LastName = "Johnson" },
                new Author { AuthorId = 7, FirstName = "Grant", LastName = "Morrison" },
                new Author { AuthorId = 8, FirstName = "Frank", LastName = "Quitely" },
            };

            var books = new[]
            {
                new Book { BookId = 1, Title = "Java The Complete Reference", Description = "A quick-reference handbook for Java programmers features detailed descriptions of the most commonly used features of Java.", Genre = BookGenre.Programming },
                new Book { BookId = 2, Title = "CLR via C#", Description = "Dig deep and master the intricacies of the common language runtime (CLR) and the .NET Framework", Genre = BookGenre.Programming },
                new Book { BookId = 3, Title = "Design Patterns: Elements of Reusable Object-Oriented Software", Description = "Design Patterns: Elements of Reusable Object-Oriented Software is a software engineering book describing software design patterns.", Genre = BookGenre.Software },
                new Book { BookId = 4, Title = "C# 4.0 The Complete Reference", Description = "The Definitive Guide to C# From using LINQ to covariance and from string formatting to optional arguments, Herb's update covers all you need to know about using real-world C#.", Genre = BookGenre.Programming },
                new Book { BookId = 5, Title = "Batman and Robin", Description = "American comic book ongoing series, created by Grant Morrison and featuring Batman and Robin.", Genre = BookGenre.Comics },
            };
            context.AddRange(
                new BookAuthor { Author = authors[0], Book = books[1] },
                new BookAuthor { Author = authors[1], Book = books[0] },
                new BookAuthor { Author = authors[1], Book = books[3] },
                new BookAuthor { Author = authors[2], Book = books[2] },
                new BookAuthor { Author = authors[3], Book = books[2] },
                new BookAuthor { Author = authors[4], Book = books[2] },
                new BookAuthor { Author = authors[5], Book = books[2] },
                new BookAuthor { Author = authors[6], Book = books[4] },
                new BookAuthor { Author = authors[7], Book = books[4] });
            context.SaveChanges();
        }
    }
}
