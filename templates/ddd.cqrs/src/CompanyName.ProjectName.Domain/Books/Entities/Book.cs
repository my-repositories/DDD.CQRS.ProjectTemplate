// Copyright (c) CompanyName.ProjectName. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyName.ProjectName.Domain.Books.Entities
{
    public enum BookGenre
    {
        Comics,
        History,
        Memoir,
        Programming,
        Software,
    }

    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public BookGenre Genre { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
