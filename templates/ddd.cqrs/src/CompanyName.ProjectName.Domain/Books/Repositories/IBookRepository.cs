// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using CompanyName.ProjectName.Domain.Books.Entities;
using DDD.CQRS.Domain;

namespace CompanyName.ProjectName.Domain.Books.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Book Get(int id);

        IEnumerable<Book> GetAll();
    }
}