// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Linq;
using CompanyName.ProjectName.Domain;
using CompanyName.ProjectName.Domain.Books.Entities;
using CompanyName.ProjectName.Domain.Books.Queries;
using DDD.CQRS.Abstract;

namespace CompanyName.ProjectName.Cli
{
    public partial class Demo
    {
        private readonly ICommandFactory commandFactory;
        private readonly IQueryFactory queryFactory;
        private readonly IAppUnitOfWork uow;

        public Demo(ICommandFactory commandFactory, IQueryFactory queryFactory, IAppUnitOfWork uow)
        {
            this.commandFactory = commandFactory;
            this.queryFactory = queryFactory;
            this.uow = uow;
        }

        public void ShowGetAllAuthorsWithBooks()
        {
            foreach (var author in uow.AuthorRepository.GetAll())
            {
                Console.WriteLine($"List of books writted by {author.FirstName} {author.LastName}:");
                foreach (var book in author.BookAuthors.Select(ba => ba.Book))
                {
                    Console.WriteLine($"   - {book.Title} ({book.Genre})");
                }

                Console.WriteLine();
            }
        }

        public void ShowGetAllBooksWithAuthors()
        {
            foreach (var book in uow.BookRepository.GetAll())
            {
                Console.WriteLine($"Authors of {book.Genre} Book {book.Title}:");
                foreach (var author in book.BookAuthors.Select(ba => ba.Author))
                {
                    Console.WriteLine($"    - {author.FirstName} {author.LastName}");
                }

                Console.WriteLine();
            }
        }

        public void ShowBookById(int id)
        {
            var book = queryFactory
                .ResolveQuery<BookByIdQuery>()
                .Execute(id);

            Console.WriteLine($"Book by id #{book.BookId}: {book.Title} - {book.Genre}");
        }

        public void ShowBooksByGenre(BookGenre genre)
        {
            var res = queryFactory
                .ResolveQuery<BooksByGenreQuery>()
                .Execute(genre);

            foreach (var book in res)
            {
                Console.WriteLine($"{book.BookId}. {book.Title} - {book.Genre}");
            }
        }
    }
}