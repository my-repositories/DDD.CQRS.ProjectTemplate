// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;

using CompanyName.ProjectName.Domain.Authors.Entities;

namespace CompanyName.ProjectName.Domain.Authors.Queries
{
    public class AuthorByIdQuery : Query
    {
        public AuthorByIdQuery(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public Author Execute(int id)
        {
            return Uow.Authors
                .FirstOrDefault(a => a.AuthorId == id);
        }
    }
}