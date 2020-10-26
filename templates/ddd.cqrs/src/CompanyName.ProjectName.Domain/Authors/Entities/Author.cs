// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using CompanyName.ProjectName.Domain.Books.Entities;

namespace CompanyName.ProjectName.Domain.Authors.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
