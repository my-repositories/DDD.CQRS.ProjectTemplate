// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Linq;
using CompanyName.ProjectName.Domain.Books.Entities;

namespace CompanyName.ProjectName.Domain.Books.Queries
{
    public class BooksByGenreQuery : Query
    {
        public BooksByGenreQuery(IAppUnitOfWork uow)
            : base(uow)
        {
        }

        public IEnumerable<Book> Execute(BookGenre genre)
        {
            return Uow.Books
                .Where(b => b.Genre == genre);
        }
    }
}
