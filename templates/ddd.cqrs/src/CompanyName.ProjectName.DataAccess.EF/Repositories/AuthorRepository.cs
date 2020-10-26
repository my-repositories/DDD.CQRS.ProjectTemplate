// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using CompanyName.ProjectName.Domain.Authors.Entities;
using CompanyName.ProjectName.Domain.Authors.Repositories;
using DDD.CQRS.DataAccess.EF;
using Microsoft.EntityFrameworkCore;

namespace CompanyName.ProjectName.DataAccess.Repositories
{
    public class AuthorRepository : EfRepository<Author, AppDbContext>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context)
            : base(context)
        {
        }

        public Author Get(int id)
        {
            return Context.Authors
                .FirstOrDefault(b => b.AuthorId == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return Context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .ToList();
        }
    }
}
