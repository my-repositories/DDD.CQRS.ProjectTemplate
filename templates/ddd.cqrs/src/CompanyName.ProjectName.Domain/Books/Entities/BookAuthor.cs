// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations.Schema;
using CompanyName.ProjectName.Domain.Authors.Entities;

namespace CompanyName.ProjectName.Domain.Books.Entities
{
    public class BookAuthor
    {
        public int AuthorId { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
