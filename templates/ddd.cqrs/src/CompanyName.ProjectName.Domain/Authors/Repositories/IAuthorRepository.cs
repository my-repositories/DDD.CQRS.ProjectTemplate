// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using CompanyName.ProjectName.Domain.Authors.Entities;
using DDD.CQRS.Domain;

namespace CompanyName.ProjectName.Domain.Authors.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author Get(int id);

        IEnumerable<Author> GetAll();
    }
}