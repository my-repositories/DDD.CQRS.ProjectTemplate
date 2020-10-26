// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using CompanyName.ProjectName.Domain.Books.Entities;
using CompanyName.ProjectName.Domain.Books.Repositories;
using DDD.CQRS.DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.ProjectName.DataAccess.Repositories
{
    public class BookRepository : EfRepository<Book, AppDbContext>, IBookRepository
    {
        public BookRepository(AppDbContext context)
            : base(context)
        {
        }

        public Book Get(int id)
        {
            return Context.Books
                .FirstOrDefault(b => b.BookId == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return Context.Books
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .ToList();
        }
    }
}
