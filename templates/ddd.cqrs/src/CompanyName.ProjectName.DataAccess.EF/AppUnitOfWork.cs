// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

using CompanyName.ProjectName.DataAccess.Repositories;
using CompanyName.ProjectName.Domain;
using CompanyName.ProjectName.Domain.Authors.Entities;
using CompanyName.ProjectName.Domain.Authors.Repositories;
using CompanyName.ProjectName.Domain.Books.Entities;
using CompanyName.ProjectName.Domain.Books.Repositories;
using DDD.CQRS.DataAccess.EF;

namespace CompanyName.ProjectName.DataAccess
{
    public class AppUnitOfWork : EfUnitOfWork<AppDbContext>, IAppUnitOfWork
    {
        private IAuthorRepository _authorRepository;

        private IBookRepository bookRepository;

        public AppUnitOfWork(AppDbContext context)
            : base(context)
        {
        }

        public IQueryable<Author> Authors => Context.Authors;

        public IQueryable<Book> Books => Context.Books;

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(Context);
                }

                return _authorRepository;
            }
        }

        public IBookRepository BookRepository
        {
            get
            {
                if (bookRepository == null)
                {
                    bookRepository = new BookRepository(Context);
                }

                return bookRepository;
            }
        }
    }
}
