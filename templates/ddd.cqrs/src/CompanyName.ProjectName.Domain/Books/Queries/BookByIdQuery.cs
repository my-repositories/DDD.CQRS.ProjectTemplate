// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Linq;
using CompanyName.ProjectName.Domain.Books.Entities;

namespace CompanyName.ProjectName.Domain.Books.Queries
{
    public class BookByIdQuery : Query
    {
        public BookByIdQuery(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public Book Execute(int id)
        {
            return Uow.Books
                .FirstOrDefault(b => b.BookId == id);
        }
    }
}
