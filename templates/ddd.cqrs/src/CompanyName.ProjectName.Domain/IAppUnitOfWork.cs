// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using CompanyName.ProjectName.Domain.Authors.Entities;
using CompanyName.ProjectName.Domain.Authors.Repositories;
using CompanyName.ProjectName.Domain.Books.Entities;
using CompanyName.ProjectName.Domain.Books.Repositories;
using DDD.CQRS.Abstract;

namespace CompanyName.ProjectName.Domain
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        IQueryable<Author> Authors { get; }

        IQueryable<Book> Books { get; }

        IAuthorRepository AuthorRepository { get; }

        IBookRepository BookRepository { get; }
    }
}
